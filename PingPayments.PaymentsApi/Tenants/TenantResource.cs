namespace PingPayments.PaymentsApi.Tenants
{
    public class TenantResource : ITenantResource
    {
        public TenantResource(ITenantV1 v1) => V1 = v1;
        public ITenantV1 V1 { get; }
    }
}
