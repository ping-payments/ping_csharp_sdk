
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record DummyParameters(PaymentStatusEnum DesiredPaymentStatus) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "desired_payment_status", DesiredPaymentStatus }
        };
    }
}
