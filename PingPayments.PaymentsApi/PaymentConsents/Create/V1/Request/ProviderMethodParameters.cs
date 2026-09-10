using System.Collections.Generic;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request
{
    public abstract record ProviderMethodParameters
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
