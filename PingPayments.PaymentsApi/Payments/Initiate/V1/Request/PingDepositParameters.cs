using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingDepositParameters
    (
        ReferenceTypeEnum ReferenceType,
        DateTimeOffset? DesiredDateOfPayment

    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "reference_type", ReferenceType },
            { "desired_date_of_payment", DesiredDateOfPayment }
        };
    }
}
