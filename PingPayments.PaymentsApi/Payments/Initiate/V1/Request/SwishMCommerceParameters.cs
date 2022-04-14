using System.Collections.Generic;
using System.Linq;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record SwishMCommerceParameters
    (
        string Message,
        SwishQrCode? SwishQrCode = null
    ) : ProviderMethodParameters
    {
        Dictionary<string, dynamic> OwnDict() => new() { { "message", Message ?? "" }, { "use_qr_code", SwishQrCode != null } };
        Dictionary<string, dynamic> QrCodeDict() => SwishQrCode?.ToDictionary() ?? new Dictionary<string, dynamic>();

        public override Dictionary<string, dynamic> ToDictionary() =>
            OwnDict().Concat(QrCodeDict()).ToLookup(x => x.Key, x => x.Value).ToDictionary(x => x.Key, g => g.First());        
    }
}
