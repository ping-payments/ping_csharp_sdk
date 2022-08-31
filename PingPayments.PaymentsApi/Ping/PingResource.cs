namespace PingPayments.PaymentsApi.Ping
{
    public class PingResource : IPingResource
    {
        public PingResource(IPingV1 v1) => V1 = v1;
        public IPingV1 V1 { get; }
    }
}
