using NorthWind.EFCore.DataContexts;
using NorthWind.EFCore.DataContexts.Guards;
using NorthWind.EFCore.DataContexts.POCOEntities;
using NorthWind.Sales.Entities.Agregates;
using NorthWind.Sales.UseCases.CreateOrder;
using System.Transactions;

namespace NorthWind.Sales.EFCore.Repositories
{
    /// <summary>
    /// Administrar las tablas para crear ordenes
    /// </summary>
    public class CreateOrderRepository : ICreateOrderRepository
    {
        readonly NorthWindLogContext Context;
        TransactionScope TransactionScope;

        /// <summary>
        /// Constructor que recibe el contexto de datos
        /// </summary>
        /// <param name="context"></param>
        public CreateOrderRepository(NorthWindLogContext context)
        {
            Context = context;
        }


        /// <summary>
        /// Crear una orden de trabajo
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(OrderAgregate order)
        {
            TransactionScope = new TransactionScope(
                TransactionScopeOption.Required, new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                });
            try
            {
                Context.Add(order);
                foreach (var item in order.OrderDetails)
                {
                    Context.Add(new OrderDetail
                    {
                        Order = order,
                        ProductId = item.ProductId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity
                    });
                }
                //se tiene que cuardar en este momento para poder tener el orderid
                DataContextGuards.SaveChanges(Context);
            }
            catch
            {
                TransactionScope.Dispose();         //hace el comit
                throw;
            }
        }

        /// <summary>
        /// Guardar los cambios
        /// </summary>
        public void SaveChanges()
        {
            TransactionScope.Complete();        //confirma los cambios
            TransactionScope.Dispose();         //hace el comit
        }

        /// <summary>
        /// Cancelar los cambios
        /// </summary>
        public void CancelChanges()
        {
            TransactionScope.Dispose();     //como no hay complete hace rolback
        }
    }
}