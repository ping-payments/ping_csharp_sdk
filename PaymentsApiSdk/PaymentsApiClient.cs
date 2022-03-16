using PaymentsApiSdk.Payments;
using PaymentsApiSdk.Payments.InitiatePayment;
using System;
using System.Net.Http;

namespace PaymentsApiSdk
{
    public class PaymentsApiClient
    {
        public PaymentsApiClient(Guid tenantId, HttpClient httpClient)
        {
            Payments = new PaymentsEndpoints
            (
                new InitiatePaymentEndpoint(tenantId, httpClient)
            );
        }

        public PaymentsEndpoints Payments { get; }
    }
}
