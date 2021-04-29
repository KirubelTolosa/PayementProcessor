namespace Kelly.Repository
{
    public interface IRepositoryService
    {
        double GetProductPrice(string productName);
        bool IsProductAvailable(string productName, int amount);
    }
}