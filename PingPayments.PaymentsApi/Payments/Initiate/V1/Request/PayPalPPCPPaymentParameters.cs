using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PayPalPPCPPaymentParameters
    (
        string Description,
        Guid DesignatedMerchantId,
        PayPalItemCategoryEnum ItemCategory,
        string Locale,
        Uri RedirectUrl,
        PayPalShipping Shipping
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "description", Description },
            { "designated_merchant_id", DesignatedMerchantId },
            { "item_category", ItemCategory },
            { "locale", Locale },
            { "redirect_url", RedirectUrl },
            { "shipping", Shipping }
        };
    }
}
