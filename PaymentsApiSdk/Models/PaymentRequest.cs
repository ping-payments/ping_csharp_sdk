using PaymentsApiSDK.Enums;
using PaymentsApiSDK.Interfaces;
using System;
using System.Collections.Generic;

namespace PaymentsApiSDK.Models
{
    public record PaymentRequest : IPaymentRequest
    {
        public PaymentRequest(
            Guid orderId,
            decimal amount,
            string currency,
            IEnumerable<IPaymentItem>
            items,
            PaymentsApiMethodEnum method,
            PaymentsApiProviderEnum provider,
            IProviderMetaData providerMetaData)
        {
            Currency = currency;
            OrderId = orderId;
            Amount = amount;
            Items = items;
            Method = method;
            Provider = provider;
            ProviderMetaData = providerMetaData;
        }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<IPaymentItem> Items { get; set; }
        public PaymentsApiMethodEnum Method { get; set; }
        public PaymentsApiProviderEnum Provider { get; set; }
        public string Currency { get; set; }
        public IProviderMetaData ProviderMetaData { get; set; }
    }
}
