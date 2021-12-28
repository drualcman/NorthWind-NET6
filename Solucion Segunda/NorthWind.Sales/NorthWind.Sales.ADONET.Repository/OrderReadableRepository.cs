using LINQExpressionToSQL;
using NorthWind.Entities.Abstractions;
using NorthWind.Sales.DTOs.Common;
using NorthWind.Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.ADONET.Repository
{
    public class OrderReadableRepository : IOrderReadableRepository, IDisposable
    {
        readonly IDbConnection Connection;
        public OrderReadableRepository(IDbConnection connection) =>
            Connection = connection;

        public IEnumerable<OrderDto> GetOrdersWithDetailsBySpecification(
            Specification<OrderDto> specification)
        {
            List<OrderDto> Orders = new List<OrderDto>();

            string Fields =
                "O.Id, O.CustomerId, O.OrderDate, O.ShipAddress, " +
                "O.ShipCity, O.ShipCountry, O.ShipPostalCode, " +
                "D.ProductId, D.UnitPrice, D.Quantity, " +
                "C.Name as CustomerName, " +
                "P.Name as ProductName";

            string Tables =
                "Orders as O inner join OrderDetails as D on " +
                "O.Id = D.OrderId inner join " +
                "Customers as C on O.CustomerId = C.Id inner join " +
                "Products as P on D.ProductId = P.Id";

            Translator Translator = new Translator();

            string Where = Translator.Translate(
                specification, specification.ConditionExpression);

            string SQL =
                $"SELECT {Fields} FROM {Tables} WHERE {Where} ORDER BY O.Id";

            var Command = Connection.CreateCommand();
            Command.CommandText = SQL;
            Connection.Open();
            var Reader = Command.ExecuteReader();
            int CurrentOrderId = 0;
            OrderDto OrderDTO;
            bool HasOrders;
            if (Reader.Read())
            {
                do
                {
                    CurrentOrderId = Convert.ToInt32(Reader["Id"]);
                    OrderDTO = new OrderDto
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        CustomerId = Reader["CustomerId"].ToString(),
                        CustomerName = Reader["CustomerName"].ToString(),
                        OrderDate = Convert.ToDateTime(Reader["OrderDate"]),
                        ShipAddress = Reader["ShipAddress"].ToString(),
                        ShipCity = Reader["ShipCity"].ToString(),
                        ShipCountry = Reader["ShipCountry"].ToString(),
                        ShipPostalCode = Reader["ShipPostalCode"].ToString(),
                        OrderDetails = new List<OrderDetailDto>()
                    };
                    do
                    {
                        OrderDTO.OrderDetails.Add(new OrderDetailDto
                        {
                            ProductId = Convert.ToInt32(Reader["ProductId"]),
                            ProductName = Reader["ProductName"].ToString(),
                            UnitPrice = Convert.ToDecimal(Reader["UnitPrice"]),
                            Quantity = Convert.ToInt16(Reader["Quantity"])
                        });
                    } while ((HasOrders = Reader.Read()) &&
                        Convert.ToInt32(Reader["Id"]) == CurrentOrderId);
                    Orders.Add(OrderDTO);
                } while (HasOrders);
            }
            Reader.Dispose();
            Command.Dispose();
            Connection.Close();
            return Orders;
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }

}
