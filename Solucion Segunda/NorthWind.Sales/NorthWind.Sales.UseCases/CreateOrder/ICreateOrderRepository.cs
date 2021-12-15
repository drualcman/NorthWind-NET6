using NorthWind.Entities.Interfaces;
using NorthWind.Sales.Entities.Agregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    
    /// <summary>
    /// abstraccion para recibir un repositorio
    /// </summary>
    public interface ICreateOrderRepository : IUnitOfWork
    {
        /// <summary>
        /// Metodo que agregara la orden en el respositorio
        /// </summary>
        /// <param name="order"></param>
        void CreateOrder(OrderAgregate order);

        /// <summary>
        /// Como se trabaja con dos repositorios, uno para el log y otro para registrar la orden.
        /// Aqui manejaremos o todo o nada en las operaciones y podremos cancelar el proceso de creacion de la orden.
        /// </summary>
        void CancelChanges();
    }
}
