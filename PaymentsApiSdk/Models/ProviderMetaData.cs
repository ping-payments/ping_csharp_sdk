using PaymentsApiSDK.Interfaces;
using System.Collections.Generic;

namespace PaymentsApiSDK.Models
{
    public abstract record ProviderMetaData : IProviderMetaData
    {
        public abstract Dictionary<string, dynamic> ToDictionary();
    }
}
