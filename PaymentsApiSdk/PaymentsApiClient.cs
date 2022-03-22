using PaymentsApiSdk.PaymentOrders;
using PaymentsApiSdk.PaymentOrders.Get;
using PaymentsApiSdk.Payments;
using PaymentsApiSdk.Payments.Get;
using PaymentsApiSdk.Payments.Initiate;
using System;
using System.Net.Http;

namespace PaymentsApiSdk
{
    public class PaymentsApiClient
    {
        public PaymentsApiClient(Guid tenantId, HttpClient httpClient)
        {
            Payments = new PaymentEndpoints
            (
                new InitiateEndpoint(httpClient, tenantId),
                new GetEndpoint(httpClient, tenantId)
            );
            PaymentOrder = new PaymentOrderEndpoints
            (
                new GetPaymentOrderEndpoint(httpClient, tenantId)
            );
        }

        public PaymentEndpoints Payments { get; }
        public PaymentOrderEndpoints PaymentOrder { get; }
    }
}
