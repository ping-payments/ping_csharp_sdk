using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record VippsProviderMethodParameters
    (
        string PaymentDescription,
        Uri ReturnUrl,
        VippsCustomer Customer
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "payment_description", PaymentDescription },
            { "prefill_customer", Customer },
            { "return_url", ReturnUrl.ToString() }
        };
    }
}
