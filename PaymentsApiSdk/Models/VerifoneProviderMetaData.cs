using PaymentsApiSDK.Interfaces;
using System.Collections.Generic;

namespace PaymentsApiSDK.Models
{
    public record VerifoneProviderMetaData
    (
        string FirstName,
        string LastName,
        string Email,
        string SuccessUrl,
        string CancelUrl
    ) : ProviderMetaData, IVerifoneProviderMetaData
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "first_name", FirstName },
            { "last_name", LastName },
            { "email", Email },
            { "success_url", SuccessUrl },
            { "cancel_url", CancelUrl }
        };
    }
}
