using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingDepositParameters
    (
        ReferenceTypeEnum ReferenceType,
        DateTimeOffset? DesiredDateOfPayment,
        string? ReuseReference

    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "reference_type", ReferenceType },
            { "reference", ReuseReference },
            { "desired_date_of_payment", DesiredDateOfPayment }
        };
    }
}
