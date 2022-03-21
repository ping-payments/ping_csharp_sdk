using PaymentsApiSdk.Payments.Shared;
using System.Collections.Generic;

namespace PaymentsApiSdk.Payments.Initiate.Request
{
    public record DummyProviderMethodParameters(PaymentStatusEnum DesiredPaymentStatus = PaymentStatusEnum.COMPLETED) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "desired_payment_status", DesiredPaymentStatus }
        };
    }
}
