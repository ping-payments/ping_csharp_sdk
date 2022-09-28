namespace PingPayments.PaymentsApi.SigningKeys
{
    public interface ISigningKeyResource
    {
        ISigningKeyV1 V1 { get; }
    }
}