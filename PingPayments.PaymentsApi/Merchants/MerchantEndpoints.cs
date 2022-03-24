namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class MerchantEndpoints : IMerchantEndpoints
    {
        public MerchantEndpoints(IMerchantV1 v1) => V1 = v1;
        public IMerchantV1 V1 { get; }
    }
}
