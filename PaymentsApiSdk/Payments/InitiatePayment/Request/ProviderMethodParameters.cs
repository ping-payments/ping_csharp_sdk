using System.Collections.Generic;

namespace PaymentsApiSdk.Payments.InitiatePayment.Request
{
    public abstract record ProviderMethodParameters
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
