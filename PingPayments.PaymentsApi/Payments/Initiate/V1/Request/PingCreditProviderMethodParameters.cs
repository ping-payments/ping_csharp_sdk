using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record PingCreditProviderMethodParameters
    (
        string LiquidityAccountId
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "liquidity_account_id", LiquidityAccountId },
        };
    }
}
