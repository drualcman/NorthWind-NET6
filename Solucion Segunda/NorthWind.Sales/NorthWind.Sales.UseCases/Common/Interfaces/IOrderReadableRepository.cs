using NorthWind.Entities.Abstractions;
using NorthWind.Sales.DTOs.Common;

namespace NorthWind.Sales.UseCases.Common.Interfaces
{
    /// <summary>
    /// abstraccion para leer de la fuente de datos
    /// </summary>
    public interface IOrderReadableRepository
    {
        /// <summary>
        /// consultar ordenes por fecha
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        IEnumerable<OrderDto> GetOrdersWithDetailsBySpecification(Specification<OrderDto> specification);
    }
}
