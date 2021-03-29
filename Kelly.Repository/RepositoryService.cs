using Microsoft.Extensions.Configuration;
using System;

namespace Kelly.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private IConfiguration _configuration;
        public RepositoryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool CheckProductAvailabliltiy(string productName)
        {
            return true;
        }
        public decimal CheckProductPrice(string productName)
        {
            return (decimal)10.5;
        }
    }
}
