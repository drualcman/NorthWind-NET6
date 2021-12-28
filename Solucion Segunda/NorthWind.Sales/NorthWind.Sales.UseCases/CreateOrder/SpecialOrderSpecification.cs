using NorthWind.Entities.Abstractions;
using NorthWind.Sales.Entities.Agregates;
using System.Linq.Expressions;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    /// <summary>
    /// definir la logica para las ordenes especiales
    /// </summary>
    public class SpecialOrderSpecification : Specification<OrderAgregate>
    {
        /// <summary>
        /// definir la expresion para la especificacion
        /// </summary>
        public override Expression<Func<OrderAgregate, bool>> ConditionExpression =>
            order => order.OrderDetails.Count > 3;
    }
}
