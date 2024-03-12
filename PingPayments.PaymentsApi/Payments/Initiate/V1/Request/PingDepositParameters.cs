using PingPayments.PaymentsApi.Payments.Shared.V1.Deposit;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingDepositParameters
    (
        ReferenceTypeEnum ReferenceType,
        string? Reference,
        bool? CompleteWhenFunded,
        string? DesiredDateOfPayment,
        Invoice? Invoice = null
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {

            { "complete_when_funded", CompleteWhenFunded ?? true },
            { "reference_type", ReferenceType },
            { "reference", Reference },
            { "desired_date_of_payment", DesiredDateOfPayment },
            { "invoice", Invoice }
        };
    }
}
