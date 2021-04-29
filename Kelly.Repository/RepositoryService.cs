using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Kelly.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private IConfiguration _configuration;
        public RepositoryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool IsProductAvailable(string productName, int amountRequested)
        {
            int countOfItemsLeft = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProductInventoryDB")))  
                {
                    using (SqlCommand sqlCommandCheckInventory = new SqlCommand(@"SELECT CountInStore as [count] FROM Products p WHERE p.ProductName = @prdName", connection))
                    {
                        connection.Open();
                        
                        sqlCommandCheckInventory.Parameters.Add("prdName", System.Data.SqlDbType.NVarChar).Value = productName;
                        SqlDataReader dataReader = sqlCommandCheckInventory.ExecuteReader();
                        if (dataReader.Read())
                        {
                            countOfItemsLeft = (Int32)dataReader["count"];
                        }
                        
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Message: {0}", ex.Message);
                throw ex;
            }
            return countOfItemsLeft - amountRequested >= 0 ? true : false;
        }
        public double GetProductPrice(string productName)
        {
            double itemPrice = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProductInventoryDB")))
                {
                    using (SqlCommand sqlCommandGetProductPrice = new SqlCommand(@"SELECT price FROM Products p WHERE p.productName = @prdName", connection))
                    {
                        connection.Open();
                        sqlCommandGetProductPrice.Parameters.Add("prdName", System.Data.SqlDbType.NVarChar).Value = productName;
                        SqlDataReader dataReader = sqlCommandGetProductPrice.ExecuteReader();
                        if (dataReader.Read())
                        {
                            itemPrice = (double)dataReader["price"];
                        }
                        
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Message: {0}", ex.Message);
                throw ex;
            }
            return itemPrice;
        }
    }
}
