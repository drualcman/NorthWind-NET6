using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWInd.Sales.ConsoleClient
{
    /// <summary>
    /// Sericio para crear la orden
    /// </summary>
    public class CreateOrderService
    {
        ICreateConsoleController Controller;

        public CreateOrderService(ICreateConsoleController controller)
        {
            Controller = controller;
        }

        public void CreateOrder()
        {
            var order = new CreateOrderDto
            {
                CustomerId = "ANTON",
                ShipAddress = "5 Sur 907",
                ShipCity = "Puebla",
                ShipCountry = "Mexico",
                ShipPostalCode = "72500",
                OrderDetails = new List<CreateOrderDetailDto>
                {
                    new CreateOrderDetailDto
                    {
                        ProductId = 1, Quantity = 10, UnitPrice = 20
                    }
                }
            };

            var view Controller.CreateOrder(order).Result;
            view.ExecuteResult();
        }
    }
}
