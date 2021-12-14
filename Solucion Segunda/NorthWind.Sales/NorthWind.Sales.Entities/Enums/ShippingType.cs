using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.Enums
{
    /// <summary>
    /// Definir los tipos de transporte
    /// </summary>
    public enum ShippingType
    {
        /// <summary>
        /// Mar 
        /// </summary>
        Sea, 
        /// <summary>
        /// Aire
        /// </summary>
        Air, 
        /// <summary>
        /// Tren
        /// </summary>
        Rail, 
        /// <summary>
        /// Caretead
        /// </summary>
        Road
    }
}
