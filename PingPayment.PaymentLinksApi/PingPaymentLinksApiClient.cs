using System;
using System.Net.Http;
using PingPayments.PaymentLinksApi.PaymentLinks;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
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


            var paymentLinksV1 = new PaymentLinksV1
            (
                new Lazy<ListPaymentLinksOperation>(() => new ListPaymentLinksOperation(httpClient)),
                new Lazy<GetPaymentLinkOperation>(()=> new GetPaymentLinkOperation(httpClient))
            );
            _paymentLinks = new Lazy<IPaymentLinksResource>(() => new PaymentLinksResource(paymentLinksV1));
        }

        private readonly Lazy<IPingResource> _ping;
        public IPingResource Ping => _ping.Value;

        private readonly Lazy<IPaymentLinksResource> _paymentLinks;
        public IPaymentLinksResource PaymentLinks => _paymentLinks.Value;
    }
}