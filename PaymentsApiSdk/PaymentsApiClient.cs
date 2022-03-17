using PaymentsApiSdk.Payments.Initiate;
using System;
using System.Net.Http;

namespace PaymentsApiSdk
{
    public class PaymentsApiClient
    {
        public PaymentsApiClient(Guid tenantId, HttpClient httpClient)
        {
            Payments = new Payments.Payments
            (
                new Initiate(tenantId, httpClient)
            );
        }

        public Payments.Payments Payments { get; }
    }
}
