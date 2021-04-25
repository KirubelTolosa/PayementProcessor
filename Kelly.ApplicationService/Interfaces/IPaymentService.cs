namespace Kelly.ApplicationService
{
    public interface IPaymentService
    {
        bool ChargeCard(string creditCardNumber, decimal amount);
    }
}