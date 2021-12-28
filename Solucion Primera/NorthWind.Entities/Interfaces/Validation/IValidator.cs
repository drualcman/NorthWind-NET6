using System.Linq.Expressions;

namespace NorthWind.Entities.Interfaces.Validation
{
    /// <summary>
    /// Encargado de realizar la validacion
    /// </summary>
    public interface IValidator<T>
    {
        /// <summary>
        /// Agregar una regla de validacion
        /// </summary>
        /// <example>
        /// AddRuleFor(Produt => Product.Name);
        /// AddRuleFor(o=> o.CustomerId)
        /// </example>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="expression"></param>
        /// <param name="stopInFirstFailure"></param>
        /// <returns></returns>
        IRule<T> AddRuleFor<TProperty>(
            //pasamos el modelo y devuelve la propiedad
            Expression<Func<T, TProperty>> expression,
            //define si hay que parar en la primera falla
            bool stopInFirstFailure);

        /// <summary>
        /// Metodo que va a hacer la validacion
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool Validate(T instance);

        /// <summary>
        /// Lista de fallos encontrados
        /// </summary>
        List<IFailure> Failures { get; }

        /// <summary>
        /// Agregar la validacion al modelo
        /// </summary>
        /// <typeparam name="ItemsTypes"></typeparam>
        /// <param name="items"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        List<IFailure> SetValidatorFor<ItemsTypes>(IEnumerable<ItemsTypes> items,
            IValidator<ItemsTypes> validator);

        /// <summary>
        /// Definir quien es el servicio de validacion
        /// </summary>
        IValidationService<T> ServiceValidator { get; }
    }
}
