using System.Collections.Generic;
using System.Linq;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record SwishRecurringParameters
    (
        string ConsentId,
        string Message
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "consent_id", ConsentId },
            { "message", Message ?? "" }
        };
    }
}
