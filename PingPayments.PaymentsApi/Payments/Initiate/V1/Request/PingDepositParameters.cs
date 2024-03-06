using PingPayments.PaymentsApi.Payments.Shared.V1.Deposit;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingDepositParameters
    (
        ReferenceTypeEnum ReferenceType,
        Invoice? Invoice,
        string? Reference,
        bool? CompleteWhenFunded,
        string? DesiredDateOfPayment
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {

            { "complete_when_funded", CompleteWhenFunded ?? true },
            { "reference_type", ReferenceType },
            { "reference", Reference },
            { "invoice", Invoice },
            { "desired_date_of_payment", DesiredDateOfPayment }
        };
    }
}
