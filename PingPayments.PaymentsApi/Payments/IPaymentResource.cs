namespace PingPayments.PaymentsApi.Payments
{
    public interface IPaymentResource
    {
        IPaymentsV1 V1 { get; }
    }
}