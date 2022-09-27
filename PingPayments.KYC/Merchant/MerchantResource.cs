namespace PingPayments.KYC.Merchant
{
    public class MerchantResource : IMerchantResource
    {
        public MerchantResource(IMerchantV1 v1) => V1 = v1;
        public IMerchantV1 V1 { get; }
    }
}
