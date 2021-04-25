namespace Kelly.Repository
{
    public interface IRepositoryService
    {
        decimal GetProductPrice(string productName);
        bool CheckProductAvailabliltiy(string productName, int amount);
    }
}