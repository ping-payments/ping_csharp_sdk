using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingDepositParameters
    (
        ReferenceTypeEnum ReferenceType,
        DateTimeOffset? DesiredDateOfPayment,
        string? reference,
        bool? CompleteWhenFunded
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {

            { "complete_when_funded", CompleteWhenFunded ?? true },
            { "reference_type", ReferenceType },
            { "reference", reference },
            { "desired_date_of_payment", DesiredDateOfPayment?.ToString("yyyy-MM-dd") }
        };
    }
}
