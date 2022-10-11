using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.Mimic.Disbursements.Trigger.V1
{
    public record TriggerDisbursementResponseBody : EmptySuccessfulResponseBody
    {

        [JsonPropertyName("disbursed_payment_orders")]
        public Guid[]? DisbursedPaymentOrders { get; set; }


        [JsonPropertyName("failed_to_disburse")]
        public FailedDisbursement[]? FailedToDisburse { get; set; }

    }
}
