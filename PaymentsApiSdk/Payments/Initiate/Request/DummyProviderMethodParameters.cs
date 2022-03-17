using System.Collections.Generic;

namespace PaymentsApiSdk.Payments.Initiate.Request
{
    public record DummyProviderMethodParameters : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new Dictionary<string, dynamic>();
    }
}
