namespace PingPayments.KYC.Agreement
{
    public class AgreementResource : IAgreementResource
    {
        public AgreementResource(IAgreementV1 v1) => V1 = v1;
        public IAgreementV1 V1 { get; }
    }
}
