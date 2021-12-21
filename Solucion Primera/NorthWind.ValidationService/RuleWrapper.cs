using NorthWind.Entities.Interfaces.Validation;
using SimpleValidationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.ValidationService
{
    /// <summary>
    /// wrapper para las reglas de validacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RuleWrapper<T> : IRule<T>
    {
        Rule<T> Rule;

        /// <summary>
        /// recibir la regla por el constructor
        /// </summary>
        /// <param name="rule"></param>
        public RuleWrapper(Rule<T> rule)
        {
            Rule = rule;
        }

        /// <summary>
        /// agregar una regla de propiedad
        /// </summary>
        /// <param name="requirement"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public IRule<T> AddRequirement(Expression<Func<T, bool>> requirement, string errorMessage)
        {
            Rule.AddRequirement(requirement, errorMessage);
            return this;
        }

        /// <summary>
        /// agregar una regla de collecciones
        /// </summary>
        /// <param name="itemsValidatorExpression"></param>
        /// <returns></returns>
        public IRule<T> AddCollectionItemsValidator(Expression<Func<T, IEnumerable<IFailure>>> itemsValidatorExpression)
        {
            Expression<Func<T, IEnumerable<KeyValuePair<string, string>>>> ItemsValidatorExpression = 
                (instance) => itemsValidatorExpression.Compile().Invoke(instance)
                .Select(s=> new KeyValuePair<string, string>(s.PropertyName, s.ErrorMessage));
            Rule.AddCollectionItemsValidator(ItemsValidatorExpression);
            return this;
        }

    }
}
