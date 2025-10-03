using System.Collections.Generic;
using PingPayments.PaymentsApi.Payments.Shared.V1.VippsMobilepayCheckout;
using System;


namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record VippsMobilepayCheckoutParameters
    (
        string PaymentDescription,
        Uri ReturnUrl,
        PrefillCustomer PrefillCustomer
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary()
        {
            return new Dictionary<string, dynamic>
            {
                { "payment_description", PaymentDescription ?? "" },
                { "phone_number", ReturnUrl },
                { "prefill_customer", PrefillCustomer },
            };
        }
    }
}
