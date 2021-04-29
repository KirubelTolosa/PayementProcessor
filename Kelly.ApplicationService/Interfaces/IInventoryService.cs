namespace Kelly.ApplicationService
{
    public interface IInventoryService
    {
        //Assuming no credit card info logging is required
        bool IsProductAvailable(string productName, int amount);
        double GetProductPrice(string productName);
    }
}