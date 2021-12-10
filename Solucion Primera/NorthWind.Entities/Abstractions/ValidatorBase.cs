using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Abstractions
{
    /// <summary>
    /// Abstracion base para los validadores
    /// </summary>
    public abstract class ValidatorBase<T> : IValidator<T> // where T : class  <- seria posible
    {
        readonly IValidationService<T> Service;

        /// <summary>
        /// Recibir por el constructor quien es el que realiza las validaciones
        /// </summary>
        /// <param name="service"></param>
        protected ValidatorBase(IValidationService<T> service)
        {
            Service = service;
        }

        /// <summary>
        /// Recoger la lista de fallos
        /// </summary>
        public List<IFailure> Failures => Service.Failures;

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
        public IRule<T> AddRuleFor<TProperty>(
            //pasamos el modelo y devuelve la propiedad
            Expression<Func<T, TProperty>> expression,
            //define si hay que parar en la primera falla
            bool stopInFirstFailure) => 
            Service.AddRuleFor(expression, stopInFirstFailure);

        /// <summary>
        /// Metodo que va a hacer la validacion
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool Validate(T instance) =>
            Service.Validate(instance);

        /// <summary>
        /// Agregar la validacion al modelo
        /// </summary>
        /// <typeparam name="ItemsTypes"></typeparam>
        /// <param name="items"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        public List<IFailure> SetValidatorFor<ItemsTypes>(IEnumerable<ItemsTypes> items,
            IValidator<ItemsTypes> validator) => 
            Service.SetValidatorFor(items, validator);

        /// <summary>
        /// Definir quien es el servicio de validacion
        /// </summary>
        public IValidationService<T> ServiceValidator => Service;
    }
}
