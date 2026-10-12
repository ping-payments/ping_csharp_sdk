using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record QuickPayApplePayParameters
    (
        Guid DesignatedMerchantId,
        IDictionary<string, dynamic> ApplePayToken
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "designated_merchant_id", DesignatedMerchantId },
            { "apple_pay_token", ApplePayToken }
        };
    }
}
