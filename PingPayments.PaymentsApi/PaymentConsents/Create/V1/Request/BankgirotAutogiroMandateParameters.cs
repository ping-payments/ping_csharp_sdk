using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request
{
    public record BankgirotAutogiroMandateParameters
    (
        LegalEntity? AccountHolder = null,
        Uri? CancelUrl = null,
        Uri? ErrorUrl = null,
        string? Locale = "sv-SE",
        string? MandateDescription = null,
        Uri? SuccessUrl = null
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>();

            if (AccountHolder != null)
            {
                dict.Add("account_holder", AccountHolder);
            }

            if (CancelUrl != null)
            {
                dict.Add("cancel_url", CancelUrl);
            }

            if (ErrorUrl != null)
            {
                dict.Add("error_url", ErrorUrl);
            }

            if (!string.IsNullOrWhiteSpace(Locale))
            {
                dict.Add("locale", Locale);
            }

            if (!string.IsNullOrWhiteSpace(MandateDescription))
            {
                dict.Add("mandate_description", MandateDescription);
            }

            if (SuccessUrl != null)
            {
                dict.Add("success_url", SuccessUrl);
            }

            return dict;
        }
    }
}
