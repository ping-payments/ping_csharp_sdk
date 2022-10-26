using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.Initiate.V1.Request
{
    public record BankgirotProviderMethodParameters
    (
        string MandateId
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "mandate_id", MandateId },
        };
    }
}
