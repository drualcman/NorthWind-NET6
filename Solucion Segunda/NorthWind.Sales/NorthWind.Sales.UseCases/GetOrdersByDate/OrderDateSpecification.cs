using NorthWind.Entities.Abstractions;
using NorthWind.Sales.DTOs.Common;
using System.Linq.Expressions;

namespace NorthWind.Sales.UseCases.GetOrdersByDate
{
    /// <summary>
    /// especificacion para hacer la consulta
    /// </summary>
    public class OrderDateSpecification : Specification<OrderDto>
    {
        readonly DateTime OrderDate;
        /// <summary>
        /// constructor que recibe la fecha a consultar
        /// </summary>
        /// <param name="orderDate"></param>
        public OrderDateSpecification(DateTime orderDate) =>
            OrderDate = orderDate;

        /// <summary>
        /// ejecutar la consulta
        /// </summary>
        public override Expression<Func<OrderDto, bool>> ConditionExpression =>
            (o => o.OrderDate.Date == OrderDate.Date);

    }

}
