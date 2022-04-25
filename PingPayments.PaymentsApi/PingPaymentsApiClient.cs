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
                new Lazy<InitiateEndpoint>(() => new InitiateEndpoint(httpClient)),
                new Lazy<GetEndpoint>(() => new GetEndpoint(httpClient))
            );
            _payments = new Lazy<IPaymentEndpoints>(() => new PaymentEndpoints(paymentsV1));

            var paymentOrderV1 = new PaymentOrderV1
            (
                 new Lazy<GetPaymentOrderEndpoint>(() => new GetPaymentOrderEndpoint(httpClient)),
                 new Lazy<CreatePaymentOrderEndpoint>(() => new CreatePaymentOrderEndpoint(httpClient)),
                 new Lazy<UpdatePaymentOrderEndpoint>(() => new UpdatePaymentOrderEndpoint(httpClient)),
                 new Lazy<ListPaymentOrderEndpoint>(() => new ListPaymentOrderEndpoint(httpClient)),
                 new Lazy<SplitPaymentOrderEndpoint>(() => new SplitPaymentOrderEndpoint(httpClient)),
                 new Lazy<ClosePaymentOrderEndpoint>(() => new ClosePaymentOrderEndpoint(httpClient)),
                 new Lazy<SettlePaymentOrderEndpoint>(() => new SettlePaymentOrderEndpoint(httpClient))
            );
            _paymentOrderEndpoints = new Lazy<IPaymentOrderEndpoints>(() => new PaymentOrderEndpoints(paymentOrderV1));

            var merchantV1 = new MerchantV1
            (
                new Lazy<CreateMerchantEndpoint>(() => new CreateMerchantEndpoint(httpClient)),
                new Lazy<GetMerchantEndpoint>(() => new GetMerchantEndpoint(httpClient)),
                new Lazy<ListMerchantsEndpoint>(() => new ListMerchantsEndpoint(httpClient))
            );
            _merchants = new Lazy<IMerchantEndpoints>(() => new MerchantEndpoints(merchantV1));
        }

        private readonly Lazy<IPaymentEndpoints> _payments;
        public IPaymentEndpoints Payments => _payments.Value;

        private readonly Lazy<IPaymentOrderEndpoints> _paymentOrderEndpoints;
        public IPaymentOrderEndpoints PaymentOrder => _paymentOrderEndpoints.Value;

        private readonly Lazy<IMerchantEndpoints> _merchants;
        public IMerchantEndpoints Merchants => _merchants.Value;
    }
}
