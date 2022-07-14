using PingPayments.Shared.Enums;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record DummyProviderMethodParameters(PaymentStatusEnum DesiredPaymentStatus = PaymentStatusEnum.COMPLETED) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "desired_payment_status", DesiredPaymentStatus }
        };
    }
}
