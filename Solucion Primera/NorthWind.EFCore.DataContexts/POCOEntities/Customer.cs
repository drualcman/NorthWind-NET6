using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts.POCOEntities
{
    /// <summary>
    /// entidad para el cliente
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// identificador
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// saldo actual
        /// </summary>
        public decimal CurrentBalance { get; set; }
    }

}
