using NorthWind.Sales.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.ADONET.Repository
{
    public class CreateOrderValidationRepository : ICreateOrderValidationRepository, IDisposable
    {
        readonly IDbConnection Connection;
        public CreateOrderValidationRepository(IDbConnection connection) =>
            Connection = connection;

        public decimal? GetCurrentBalance(string customerId)
        {
            string SQL =
                "Select CurrentBalance from Customers where Id = @CustomerId";
            var Command = Connection.CreateCommand();
            Command.CommandText = SQL;
            var Parameter = Command.CreateParameter();
            Parameter.ParameterName = "@CustomerId";
            Parameter.Value = customerId;
            Command.Parameters.Add(Parameter);
            Connection.Open();
            var Result = Command.ExecuteScalar();
            decimal? CurrentBalance = Result != null ?
                Convert.ToDecimal(Result) : null;
            Command.Dispose();
            Connection.Close();
            return CurrentBalance;
        }

        public Dictionary<int, int> GetUnitsInStock(
            List<int> productIds)
        {
            var Result = new Dictionary<int, int>();

            string Fields =
                "Id, UnitsInStock";
            string Where =
                $"Id in ({string.Join(",", productIds)})";

            string SQL =
                $"SELECT {Fields} FROM Products WHERE {Where};";

            var Command = Connection.CreateCommand();
            Command.CommandText = SQL;
            Connection.Open();

            var Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Result.Add(
                    Reader.GetInt32(0), Reader.GetInt32(1));
            }
            Reader.Dispose();
            Command.Dispose();
            Connection.Close();
            return Result;
        }





        public void Dispose()
        {
            Connection?.Dispose();
        }
    }

}
