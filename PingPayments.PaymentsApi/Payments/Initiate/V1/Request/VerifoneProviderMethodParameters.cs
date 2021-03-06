using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record VerifoneProviderMethodParameters
    (
        string FirstName,
        string LastName,
        string Email,
        Uri SuccessUrl,
        Uri CancelUrl
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "first_name", FirstName },
            { "last_name", LastName },
            { "email", Email },
            { "success_url", SuccessUrl.ToString() },
            { "cancel_url", CancelUrl.ToString() }
        };
    }
}
