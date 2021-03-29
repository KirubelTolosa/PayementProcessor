namespace Kelly.ApplicationService
{
    public interface IPaymentService
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
    }
}