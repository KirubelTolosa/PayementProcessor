namespace Kelly.ApplicationService
{
    public interface IInventoryService
    {
        //Assuming no credit card info logging is required
        bool CheckProductAvailabliltiy(string productName, int amount);
        decimal GetProductPrice(string productName);
    }
}