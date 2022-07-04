
namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record SwishCommerceParameters (string Message) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "swish_message" , Message }
        };
    }
}