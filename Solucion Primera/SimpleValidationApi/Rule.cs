using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationApi
{
    /// <summary>
    /// Manejar las reglas de validacion
    /// </summary>
    public class Rule<T>
    {
        /// <summary>
        /// Validaciones a realizar
        /// </summary>
        readonly List<ValidationExpression> ValidationExpressions = 
            new List<ValidationExpression>();
        readonly bool StopOnFirstFailure = false;
        /// <summary>
        /// campos que causaron fallos
        /// </summary>
        readonly List<Failure> FailuresField = new List<Failure>();
        /// <summary>
        /// Campo que vamos a validar como expresin lambda
        /// </summary>
        readonly LambdaExpression PropertyExpressionField;

        /// <summary>
        /// constructor que recibe la expresion a analizar
        /// </summary>
        /// <param name="propertyExpression"></param>
        /// <param name="stopOnFailure"></param>
        public Rule(LambdaExpression propertyExpression, bool stopOnFailure) =>
            (PropertyExpressionField, StopOnFirstFailure) = (propertyExpression, stopOnFailure);

        /// <summary>
        /// exponer los fallos para que puedan ser obtenidos
        /// </summary>
        public List<Failure> Failures => FailuresField;

        /// <summary>
        /// Metodo para agregar un requerimiento
        /// </summary>
        /// <param name="requirement"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public Rule<T> AddRequirement(Expression<Func<T, bool>> requirement, string errorMessage) 
        {
            ValidationExpressions.Add(new ValidationExpression(requirement, errorMessage));
            return this;
        }
        
        /// <summary>
        /// Agregar validadores de collecciones
        /// </summary>
        /// <param name="itemsValidatorExpression"></param>
        /// <returns></returns>
        public Rule<T> AddCollectionItemsValidator(Expression<Func<T, 
            IEnumerable<KeyValuePair<string, string>>>> itemsValidatorExpression)
        {
            ValidationExpressions.Add(
                new ValidationExpression(itemsValidatorExpression, ""));
            return this;
        }

        /// <summary>
        /// El validado de la propiedad o instancia
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool IsValid(T instance)
        {
            Failures.Clear();
            var enumerator = ValidationExpressions.GetEnumerator();
            bool Continue = true;
            while(enumerator.MoveNext() && Continue)
            {
                try
                {
                    if (enumerator.Current.Expression is
                        Expression<Func<T, bool>> validationExpression)
                    {
                        // si es un Func<T,bool> es una validacion de un requerimiento
                        if (!validationExpression.Compile().Invoke(instance))
                        {
                            //hace la validacion
                            Failures.Add(new Failure(RulePropertyName, enumerator.Current.ErrorMessage));
                            Continue = !StopOnFirstFailure;
                        }
                    }
                    else
                    {
                        //ahora validamos una collecion
                        var validatorExpression = enumerator.Current.Expression as 
                            Expression<Func<T, IEnumerable<KeyValuePair<string, string>>>>; 
                        var failuresFound = validatorExpression.Compile().Invoke(instance);
                        if (failuresFound.Any())
                        {
                            Failures.AddRange(failuresFound.Select(f => new Failure(f.Key, f.Value)));
                            Continue = !StopOnFirstFailure;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return !Failures.Any();

        }

        /// <summary>
        /// devuelve el nombre de la propiedad
        /// </summary>
        string RulePropertyName
        {
            get
            {
                string name;
                //recuperar el nombre de la propiedad
                var memberExpression = PropertyExpressionField.Body as MemberExpression;
                if (memberExpression != null)
                {
                    name = memberExpression.Member.Name;
                }
                else
                {
                    //si no es una propiedad devuelve el nombre del modelo
                    name = PropertyExpressionField.Body.Type.Name;
                }
                return name;
            }
        }
    }
}
