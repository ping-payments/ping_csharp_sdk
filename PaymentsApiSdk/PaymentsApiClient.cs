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
        }

        public PaymentEndpoints Payments { get; }
    }
}
