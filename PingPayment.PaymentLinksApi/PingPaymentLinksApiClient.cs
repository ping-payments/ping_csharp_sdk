using PingPayments.PaymentLinksApi.Ping;
using PingPayments.PaymentLinksApi.Ping.V1;
using PingPayments.PaymentLinksApi.PaymentLinks;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Cancel.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1;

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
                new Lazy<CreatePaymentLinkOperation>(() => new CreatePaymentLinkOperation(httpClient)),
                new Lazy<GetPaymentLinkOperation>(()=> new GetPaymentLinkOperation(httpClient)),
                new Lazy<CancelPaymentLinkOperation>(()=> new CancelPaymentLinkOperation(httpClient)),
                new Lazy<SendPaymentLinkOperation>(()=> new SendPaymentLinkOperation(httpClient))
            );
            _paymentLinks = new Lazy<IPaymentLinksResource>(() => new PaymentLinkResource(paymentLinksV1));
        }

        private readonly Lazy<IPingResource> _ping;
        public IPingResource Ping => _ping.Value;

        private readonly Lazy<IPaymentLinksResource> _paymentLinks;
        public IPaymentLinksV1 PaymentLinks => _paymentLinks.Value;
    }
}