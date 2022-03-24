namespace PingPayments.PaymentsApi.Payments
{
    public interface IPaymentEndpoints
    {
        IPaymentsV1 V1 { get; }
    }
}