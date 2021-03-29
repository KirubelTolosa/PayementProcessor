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
        public bool CheckProductAvailabliltiy(string productName, int amount)
        {
            return _repositoryService.CheckProductAvailabliltiy(productName, amount);
        }

        public decimal CheckProductPrice(string productName)
        {
            return _repositoryService.CheckProductPrice(productName);
        }
    }
}
