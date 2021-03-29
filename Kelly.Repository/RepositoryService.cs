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
        public bool CheckProductAvailabliltiy(string productName, int amountRequested)
        {
            int countOfItemsLeft = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProductInventoryDB")))
                {
                    using (SqlCommand sqlCommandCheckInventory = new SqlCommand(@"SELECT count FROM Products p WHERE p.productName == @prdName", connection))
                    {
                        sqlCommandCheckInventory.Parameters.Add("prdName", System.Data.SqlDbType.NVarChar).Value = productName;
                        
                        countOfItemsLeft = (Int32)sqlCommandCheckInventory.ExecuteReader()["count"];
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
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);
                throw ex;
            }
            return countOfItemsLeft - amountRequested > 0 ? true : false;
        }
        public decimal CheckProductPrice(string productName)
        {
            return (decimal)10.5;
        }
    }
}
