

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record VerifoneParameters
    (
        string FirstName,
        string LastName,
        string Email,
        Uri SuccessUrl,
        Uri CancelUrl
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "first_name", FirstName },
            { "last_name", LastName },
            { "email", Email },
            { "success_url", SuccessUrl.ToString() },
            { "cancel_url", CancelUrl.ToString() }
        }; 
    }
}
