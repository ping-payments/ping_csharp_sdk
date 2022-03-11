using PaymentsApiSDK.Enums;
using System;
using System.Collections.Generic;

namespace PaymentsApiSDK.Interfaces
{
    public interface IPaymentRequest
    {
        Guid OrderId { get; set; }
        decimal Amount { get; set; }
        IEnumerable<IPaymentItem> Items { get; set; }
        PaymentsApiMethodEnum Method { get; set; }
        PaymentsApiProviderEnum Provider { get; set; }
        string Currency { get; set; }
        IProviderMetaData ProviderMetaData { get; set; }
    }
}
