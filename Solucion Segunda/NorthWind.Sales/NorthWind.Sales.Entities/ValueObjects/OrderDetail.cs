using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.ValueObjects
{
    /// <summary>
    /// Almacenar los datos de la orden
    /// Los value objects son inmutables, por lo que no deben de ser modificados.
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// producto seleccionado
        /// </summary>
        public int ProductId { get;  }
        /// <summary>
        /// precio del product
        /// </summary>
        public decimal UnitPrice { get;  }
        /// <summary>
        /// cantidad ordenada
        /// </summary>
        public short Quantity { get;  }

        /// <summary>
        /// parapoder asignar los valores solo se pueden rellenar los valores por el contructor
        /// </summary>
        /// <param name="productId">identificador del producto</param>
        /// <param name="unitPrice">precio</param>
        /// <param name="quantity">cantidad</param>
        public OrderDetail(int productId, decimal unitPrice, short quantity)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Agregar a la cantidad una nueva cantidad
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderDetail AddQuantity(short quantity) =>
            new OrderDetail(ProductId, UnitPrice, (short)(Quantity + quantity));
    }
}
