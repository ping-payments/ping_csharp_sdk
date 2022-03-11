using PaymentsApiSDK.Interfaces;
using System.Collections.Generic;

namespace PaymentsApiSDK.Models
{
    public record SwishProviderMetaData
    (
        string Message,
        string PhoneNumber
    ) : ProviderMetaData, ISwishProviderMetaData
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "message", Message ?? "" },
            { "phone_number", PhoneNumber }
        };
    }
}
