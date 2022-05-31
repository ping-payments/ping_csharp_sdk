namespace PingPayments.PaymentsApi.Payments
{
    public interface IPingResource
    {
        IPingV1 V1 { get; }
    }
}