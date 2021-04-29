namespace Kelly.ApplicationService
{
    public interface IPaymentService
    {
        bool ChargeCard(CreditCardInfoApplicationServiceDto creditCardNumber, double amount);
        bool ChargePayement(CreditCardInfoApplicationServiceDto creditCardInfo, double amount);
    }
}