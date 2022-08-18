using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record BaaseProviderMethodParameters
    (
        string RedirectUrl,
        string QrCode

    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "redirect_url", RedirectUrl },
            { "qrCode", QrCode },
        };
    }
}