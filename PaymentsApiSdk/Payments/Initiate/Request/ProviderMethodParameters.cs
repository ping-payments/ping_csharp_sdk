using System.Collections.Generic;

namespace PaymentsApiSdk.Payments.Initiate.Request
{
    public abstract record ProviderMethodParameters
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
