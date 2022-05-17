using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record SwishQrCode(SwishQrCodeFormat Format = SwishQrCodeFormat.transparent_svg, int Border = 1, int Size = 300)
    {
        public Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "qr_border", Border },
            { "qr_format", Format },
            { "qr_size", Size }
        };
    }
}
