using Kelly.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kelly.ApplicationService
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepositoryService _repositoryService;
        public InventoryService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }
        public bool IsProductAvailable(string productName, int amount)
        {
            return _repositoryService.IsProductAvailable(productName, amount);
        }

        public double GetProductPrice(string productName)
        {
            return _repositoryService.GetProductPrice(productName);
        }
    }
}
