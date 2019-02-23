using Dapper;
using Data.Models;
using Repo.DbContext;
using Repo.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repositories
{
    public class ProductRepository
    {
        private static string _connString;
        public ProductRepository()
        {
            _connString = StaticsStorage.ConnectionString;
        }

        public IEnumerable<Products> GetProducsInfoByKeywords(string keyword)
        {
            using (IDbConnection connection = new SqlConnection(_connString))
            {
                connection.Open();

                var results = connection.QueryMultiple(Resolvers.ResolveQueryByName("products.get.all.bykeywords"), new { keyword });

                var products = results.Read<Products>().AsList();
                var productDetails = results.Read<ProductDetails>().AsList();
                var stocks = results.Read<Stocks>().AsList();

                var productResult = products.Join(productDetails, p => p.ID, pd => pd.ID, (p, pdd) => new Products
                {
                    ID = p.ID,
                    Name = p.Name,
                    ProductDetails = new ProductDetails
                    {
                        ID = pdd.ID,
                        Color = pdd.Color,
                        Description = pdd.Description
                    }
                }).AsList();

                for (int i = 0; i < products.Count; i++)
                {
                    Type type = productResult[i].Stocks.GetType();
                    PropertyInfo propertyInfo = type.GetProperty("Qty");
                    PropertyInfo propertyInfo2 = type.GetProperty("ProductID");
                    propertyInfo.SetValue(productResult[i].Stocks, stocks[i].Qty);
                    propertyInfo2.SetValue(productResult[i].Stocks, stocks[i].ProductID);
                }

                connection.Close();

                return productResult;
            }
        }

        public void AddProduct(Products product)
        {
            using (IDbConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                if (product != null)
                    connection.Execute(Resolvers.ResolveQueryByName("products.add.product"), new
                      {
                          name = product.Name,
                          color = product.ProductDetails.Color,
                          description = product.ProductDetails.Description
                      });

            }
        }

        public void EditProduct(Products product)
        {
            using (IDbConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                if (product != null)
                    connection.Execute(Resolvers.ResolveQueryByName("products.update.product"), new
                    {
                        id = product.ID,
                        name = product.Name
                    });
                
                connection.Execute(Resolvers.ResolveQueryByName("products.update.product.detail"), new
                {
                    id = product.ID,
                    color = product.ProductDetails.Color,
                    description = product.ProductDetails.Description
                });
            }
        }

        public void DeleteProduct(int Id)
        {
            using (IDbConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                connection.Execute(Resolvers.ResolveQueryByName("products.delete"), new { id = Id});
            }
        }
    }
}
