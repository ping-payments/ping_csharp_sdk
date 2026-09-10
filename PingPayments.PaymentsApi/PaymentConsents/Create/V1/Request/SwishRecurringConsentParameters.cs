using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using System.Collections.Generic;
using System.Linq;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request
{
    public record SwishRecurringConsentParameters
    (
        string Tin,
        string? PhoneNumber = null,
        SwishQrCode? SwishQrCode = null
    ) : ProviderMethodParameters
    {
        Dictionary<string, dynamic> OwnDict()
        {
            var dict = new Dictionary<string, dynamic>
            {
                { "tin", Tin },
                { "use_qr_code", SwishQrCode != null }
            };

            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                dict.Add("phone_number", PhoneNumber);
            }

            return dict;
        }

        Dictionary<string, dynamic> QrCodeDict() => SwishQrCode?.ToDictionary() ?? new Dictionary<string, dynamic>();

        public override Dictionary<string, dynamic> ToDictionary() =>
            OwnDict().Concat(QrCodeDict()).ToLookup(x => x.Key, x => x.Value).ToDictionary(x => x.Key, g => g.First());
    }
}
