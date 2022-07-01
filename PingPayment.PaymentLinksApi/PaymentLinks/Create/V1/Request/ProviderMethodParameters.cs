using System.Collections.Generic;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public abstract record ProviderMethodParameters
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
