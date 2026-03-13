using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record QuickPayVippsParameters
    (
        Uri RedirectUrl,
        Guid DesignatedMerchantId,
        string? PaymentText = null,
        bool Framed = false,
        string? Language = null
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary()
        {
            var dict = new Dictionary<string, dynamic>
            {
                { "redirect_url", RedirectUrl },
                { "framed", Framed },
            };

            if (PaymentText is not null)
                dict["payment_text"] = PaymentText;

            if (Language is not null)
                dict["language"] = Language;

            dict["designated_merchant_id"] = DesignatedMerchantId;

            return dict;
        }
    }
}
