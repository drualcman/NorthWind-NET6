using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationApi
{
    /// <summary>
    /// Hacer la validacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Validator<T>
    {
        readonly List<Rule<T>> Rules = new List<Rule<T>>();
        readonly List<Failure> FailuresFields = new List<Failure>();

        /// <summary>
        /// Agregar una regla a la collecion de reglar a ser validades
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <param name="stopOnFirstFailure"></param>
        /// <returns></returns>
        public Rule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool stopOnFirstFailure)
        {
            var rule = new Rule<T>(expression, stopOnFirstFailure);
            Rules.Add(rule);
            return rule;
        }

        /// <summary>
        /// Ejecutar las validaciones
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Validate(T instance)
        {
            FailuresFields.Clear(); 
            if (Rules.Any())
            {
                foreach (Rule<T> rule in Rules)
                {
                    if (!rule.IsValid(instance))
                    {
                        FailuresFields.AddRange(rule.Failures);
                    }
                }
            }
            return FailuresFields == null || !FailuresFields.Any();
        }

        /// <summary>
        /// Exponer los fallos encontrados
        /// </summary>
        public List<Failure> Failures => FailuresFields;

        /// <summary>
        /// Validamos las collecciones
        /// </summary>
        /// <typeparam name="ItemsType"></typeparam>
        /// <param name="items"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        public List<Failure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items, 
            Validator<ItemsType> validator)
        {
            List<Failure> result = new List<Failure>();
            int itemsCount = items.Count();
            for (int i = 0; i < itemsCount; i++)
            {
                bool isValid = validator.Validate(items.ElementAt(i));
                if (!isValid)
                {
                    result.AddRange(validator.Failures
                        .Select(f => new Failure($"[{i}] {f.PropertyName}", f.ErrorMessage)).ToList());
                }
            }
            return result;
        }
    }
}
