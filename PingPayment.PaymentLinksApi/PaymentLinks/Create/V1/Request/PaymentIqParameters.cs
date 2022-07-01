namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record PaymentIqParameters
        (
            string SuccessUrl,
            string ErrorUrl,
            string? Locale
        ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "success_url", SuccessUrl.ToString() },
            { "error_url", ErrorUrl.ToString() },
            { "locale", Locale ?? String.Empty }
        };
    }
}