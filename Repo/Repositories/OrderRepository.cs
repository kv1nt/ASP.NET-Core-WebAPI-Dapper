using Data.Models;
using Repo.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Repo.Repositories
{
    public class OrderRepository
    {
        private static  string _connString;
        public OrderRepository()
        {
            _connString = StaticsStorage.ConnectionString;
        }

        //Inspect Multiple .Joins()
        //var query = orders.Join(orderDetails, p => p.ID, pc => pc.OrderID, (p, pc) => new { product = p, productcategory = pc })
        //   .Join(products, ppc => ppc.productcategory.ProductID, c => c.ID, (ppc, c) => new { productproductcategory = ppc, category = c }).Cast<Orders>();

        public IEnumerable<Orders> GetOrderInfoByDate(DateTime orderDate)
        {

            using (IDbConnection connection = new SqlConnection(_connString))
            {
                connection.Open();

                var results = connection.QueryMultiple(@"
                SELECT * FROM Orders o WHERE o.OrderDate = @orderDate; 
                SELECT * FROM OrderDetails;
                ", new { orderDate});

                var orders = results.Read<Orders>().AsList();
                var orderDetails = results.Read<OrderDetails>().AsList();

                var oredersResult = orders.Join(orderDetails, o => o.ID, od => od.OrderID, (o, odd) => new Orders
                {
                    ID = o.ID,
                    OrderDate = o.OrderDate,

                    OrderDetails = new OrderDetails
                    {
                        OrderID = odd.OrderID,
                        Price = odd.Price,
                        TotalPrice = odd.TotalPrice,
                        Qty = odd.Qty
                    }
                });
        
                return oredersResult;
            }
        }

    }
}
