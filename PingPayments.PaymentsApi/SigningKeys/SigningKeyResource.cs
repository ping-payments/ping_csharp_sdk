namespace PingPayments.PaymentsApi.SigningKeys
{
    public class SigningKeyResource : ISigningKeyResource
    {
        public SigningKeyResource(ISigningKeyV1 v1) => V1 = v1;
        public ISigningKeyV1 V1 { get; }
    }
}
