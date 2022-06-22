using System;
using System.Net.Http;
using PingPayments.PaymentLinksApi.Ping;
using PingPayments.PaymentLinksApi.Ping.V1; 

namespace PingPayments.PaymentLinksApi
{
    public class PingPaymentLinksApiClient : IPingPaymentLinksApiClient
    {
        public PingPaymentLinksApiClient(HttpClient httpClient)
        {
            var pingV1 = new PingV1
            (
                new Lazy<PingOperation>(() => new PingOperation(httpClient))
            );
            _ping = new Lazy<IPingResource>(() => new PingResource(pingV1)); 
        }

        private readonly Lazy<IPingResource> _ping;
        public IPingResource Ping => _ping.Value;
    }
}