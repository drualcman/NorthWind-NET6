using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    /// <summary>
    /// validador paracrear ordenes
    /// </summary>
    public interface ICreateOrderValidationRepository
    {
        /// <summary>
        /// conocer el balance actual
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        decimal? GetCurrentBalance(string customerId);
        /// <summary>
        /// conocer las unidades en stock
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        Dictionary<int, int> GetUnitsInStock(List<int> productIds);
    }
}
