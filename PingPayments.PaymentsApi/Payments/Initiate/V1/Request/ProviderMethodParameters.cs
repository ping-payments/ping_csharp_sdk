using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public abstract record ProviderMethodParameters
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
