using Dapper;
using Data.Models;
using Repo.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Repo.Repositories
{
    public class CustomerRepository
    {
        private readonly string _connString;
        public CustomerRepository()
        {
            _connString = StaticsStorage.ConnectionString;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            using (IDbConnection connection = new SqlConnection(_connString))
            {
                connection.Open();

                var query = connection.QueryMultiple(@"SELECT * FROM Customers;");
                var customers = query.Read<Customers>().AsList();

                return customers;
            }
        }

        //Call stored procedure to find customers by  last name or city
        public IEnumerable<Customers> FindCustomers(string lastName , string city)
        {
            using (IDbConnection connection = new SqlConnection(_connString)) {
            connection.Open();

            var customers = connection.Query<Customers>("dbo.spSearchCustomer", new { LName = lastName, City = city },
                            commandType: CommandType.StoredProcedure).ToList();
            return customers;
            }
        }
    }
}
