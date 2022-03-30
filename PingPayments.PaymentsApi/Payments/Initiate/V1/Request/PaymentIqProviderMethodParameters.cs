using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PaymentIqProviderMethodParameters
    (
        Uri SuccessUrl,
        Uri CancelUrl
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "success_url", SuccessUrl.ToString() },
            { "cancel_url", CancelUrl.ToString() }
        };
    }
}
