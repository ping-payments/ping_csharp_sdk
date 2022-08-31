using PingPayments.PaymentsApi.Merchants;
using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.Get.V1;
using PingPayments.PaymentsApi.Merchants.List.V1;
using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.PaymentOrders.Close.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Settle.V1;
using PingPayments.PaymentsApi.PaymentOrders.Split.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1;
using PingPayments.PaymentsApi.Payouts;
using PingPayments.PaymentsApi.Payouts.Get.V1;
using PingPayments.PaymentsApi.Payouts.List.V1;
using PingPayments.PaymentsApi.Ping;
using PingPayments.PaymentsApi.Ping.V1;
using System;
using System.Net.Http;


namespace PingPayments.PaymentsApi
{
    /// <summary>
    /// Client for the Payments API
    /// </summary>
    public class PingPaymentsApiClient : IPingPaymentsApiClient
    {
        public PingPaymentsApiClient(HttpClient httpClient)
        {
            var paymentsV1 = new PaymentsV1
            (
                new Lazy<InitiateOperation>(() => new InitiateOperation(httpClient)),
                new Lazy<GetOperation>(() => new GetOperation(httpClient))
            );
            _payments = new Lazy<IPaymentResource>(() => new PaymentResource(paymentsV1));

            var paymentOrderV1 = new PaymentOrderV1
            (
                 new Lazy<GetPaymentOrderOperation>(() => new GetPaymentOrderOperation(httpClient)),
                 new Lazy<CreatePaymentOrderOperation>(() => new CreatePaymentOrderOperation(httpClient)),
                 new Lazy<UpdatePaymentOrderOperation>(() => new UpdatePaymentOrderOperation(httpClient)),
                 new Lazy<ListPaymentOrderOperation>(() => new ListPaymentOrderOperation(httpClient)),
                 new Lazy<SplitPaymentOrderOperation>(() => new SplitPaymentOrderOperation(httpClient)),
                 new Lazy<ClosePaymentOrderOperation>(() => new ClosePaymentOrderOperation(httpClient)),
                 new Lazy<SettlePaymentOrderOperation>(() => new SettlePaymentOrderOperation(httpClient))
            );
            _paymentOrderResource = new Lazy<IPaymentOrderResource>(() => new PaymentOrderResource(paymentOrderV1));

            var merchantV1 = new MerchantV1
            (
                new Lazy<CreateMerchantOperation>(() => new CreateMerchantOperation(httpClient)),
                new Lazy<GetMerchantOperation>(() => new GetMerchantOperation(httpClient)),
                new Lazy<ListMerchantsOperation>(() => new ListMerchantsOperation(httpClient))
            );
            _merchants = new Lazy<IMerchantResource>(() => new MerchantResource(merchantV1));

            _ping = new Lazy<IPingResource>(() => new PingResource(new PingV1(new Lazy<PingOperation>(() => new PingOperation(httpClient)))));

            var payoutV1 = new PayoutV1
            (
                new Lazy<ListPayoutOperation>(() => new ListPayoutOperation(httpClient)),
                new Lazy<GetPayoutOperation>(() => new GetPayoutOperation(httpClient))
            );
            _payoutResource = new Lazy<IPayoutResource>(() => new PayoutResource(payoutV1));
        }

        private readonly Lazy<IPaymentResource> _payments;
        public IPaymentResource Payments => _payments.Value;

        private readonly Lazy<IPaymentOrderResource> _paymentOrderResource;
        public IPaymentOrderResource PaymentOrder => _paymentOrderResource.Value;

        private readonly Lazy<IMerchantResource> _merchants;
        public IMerchantResource Merchants => _merchants.Value;

        private readonly Lazy<IPingResource> _ping;
        public IPingResource Ping => _ping.Value;

        private readonly Lazy<IPayoutResource> _payoutResource;
        public IPayoutResource Payouts => _payoutResource.Value;
    }
}
