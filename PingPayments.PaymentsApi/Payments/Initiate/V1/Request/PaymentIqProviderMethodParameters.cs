using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PaymentIqProviderMethodParameters
    (
        Uri SuccessUrl,
        Uri ErrorUrl,
        string Locale = "en-us",
        Cashier Cashier = null
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "success_url", SuccessUrl.ToString() },
            { "error_url", ErrorUrl.ToString() },
            { "locale", Locale },
            { "cashier", Cashier }
        };
    }
}
