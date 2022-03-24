using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.Initiate.Request
{
    public abstract record ProviderMethodParameters
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
