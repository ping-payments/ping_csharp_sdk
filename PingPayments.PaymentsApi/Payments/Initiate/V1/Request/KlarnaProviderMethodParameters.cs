using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record KlarnaProviderMethodParameters
    (
        KlarnaAddress? billingAddress,
        Guid designatedMerchantId,
        KlarnaHppOptions? hppOptions,
        string locale,
        string merchantReference,
        string purchaseCountry,
        KlarnaRedirectUrls redirectUrls,
        KlarnaAddress? shippingAddress
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "billing_address", billingAddress },
            { "designated_merchant_id", designatedMerchantId },
            { "hpp_options", hppOptions },
            { "locale", locale },
            { "merchant_reference", merchantReference },
            { "purchase_country", purchaseCountry },
            { "redirect_urls", redirectUrls },
            { "shipping_address", shippingAddress }
        };
    }
}
