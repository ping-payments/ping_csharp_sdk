using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record QuickPayCardParameters
    (
        Uri RedirectUrl,
        Guid DesignatedMerchantId,
        QuickPayBrandingEnum Branding = QuickPayBrandingEnum.standard,
        bool Framed = false,
        string? Language = null
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>
            {
                { "redirect_url", RedirectUrl },
                { "designated_merchant_id", DesignatedMerchantId },
                { "branding", Branding },
                { "framed", Framed },
            };

            if (Language is not null)
                dict["language"] = Language;

            return dict;
        }
    }
}
