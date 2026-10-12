using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record QuickPayGooglePayParameters
    (
        Guid DesignatedMerchantId,
        string GooglePayToken
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "designated_merchant_id", DesignatedMerchantId },
            { "google_pay_token", GooglePayToken }
        };
    }
}
