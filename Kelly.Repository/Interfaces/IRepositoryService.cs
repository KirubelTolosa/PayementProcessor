namespace Kelly.Repository
{
    public interface IRepositoryService
    {
        decimal CheckProductPrice(string productName);
        bool CheckProductAvailabliltiy(string productName);
    }
}