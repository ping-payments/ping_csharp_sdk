using PingPayments.Shared.Enums;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingDepositParameters
    (
        ReferenceTypeEnum ReferenceType
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "reference_type", ReferenceType }
        };
    }
}
