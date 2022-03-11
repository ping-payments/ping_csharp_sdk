using System.Collections.Generic;

namespace PaymentsApiSDK.Interfaces
{
    public interface IProviderMetaData
    {
        Dictionary<string, dynamic> ToDictionary();
    }
}