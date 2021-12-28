using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts.POCOEntities
{
    /// <summary>
    /// entidad de producto
    /// </summary>
    public class Product
    {
        /// <summary>
        /// identificador
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// unidades en existencia
        /// </summary>
        public int UnitsInStock { get; set; }
        /// <summary>
        /// precio
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// discontinuado
        /// </summary>
        public bool Discontinued { get; set; }
    }

}
