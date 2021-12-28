using NorthWind.Entities.Interfaces.Validation;
using SimpleValidationApi;
using System.Linq.Expressions;

namespace NorthWind.ValidationService
{
    /// <summary>
    /// Wrapper para hacer la validacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidatorWrapper<T> : IValidationService<T>
    {
        readonly Validator<T> ApiValidatorField;

        /// <summary>
        /// recibir el validador
        /// </summary>
        public ValidatorWrapper()
        {
            ApiValidatorField = new Validator<T>();
        }

        /// <summary>
        /// devolver los fallos
        /// </summary>
        public List<IFailure> Failures =>
            ApiValidatorField.Failures.Select(
                f => new Failure(f.PropertyName, f.ErrorMessage))
            .ToList<IFailure>();

        /// <summary>
        /// devolverse a si mismo como validador
        /// </summary>
        public IValidationService<T> ServiceValidator => this;

        /// <summary>
        /// devolver el validador
        /// </summary>
        public Validator<T> ValidatorApi => ApiValidatorField;

        /// <summary>
        /// agregar una regla
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <param name="stopInFirstFailure"></param>
        /// <returns></returns>
        public IRule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool stopInFirstFailure)
        {
            var result = ApiValidatorField.AddRuleFor(expression, stopInFirstFailure);
            return new RuleWrapper<T>(result);
        }

        /// <summary>
        /// crear una validacion para una propiedad
        /// </summary>
        /// <typeparam name="ItemsTypes"></typeparam>
        /// <param name="items"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        public List<IFailure> SetValidatorFor<ItemsTypes>(IEnumerable<ItemsTypes> items, IValidator<ItemsTypes> validator)
        {
            var serviceValidator = validator.ServiceValidator as ValidatorWrapper<ItemsTypes>;
            var itemsValidatorApi = serviceValidator.ValidatorApi;
            return ApiValidatorField.SetValidatorFor(items, itemsValidatorApi)
                .Select(f => (IFailure)new Failure(f.PropertyName, f.ErrorMessage))
                .ToList();
        }

        /// <summary>
        /// Hacer la validacion
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Validate(T instance) =>
            ApiValidatorField.Validate(instance);
    }
}
