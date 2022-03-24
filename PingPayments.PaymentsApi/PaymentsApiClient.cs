using PingPayments.PaymentsApi.Merchants.Create;
using PingPayments.PaymentsApi.Merchants.Get;
using PingPayments.PaymentsApi.Merchants.List;
using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.PaymentOrders.Close;
using PingPayments.PaymentsApi.PaymentOrders.Create;
using PingPayments.PaymentsApi.PaymentOrders.Get;
using PingPayments.PaymentsApi.PaymentOrders.List;
using PingPayments.PaymentsApi.PaymentOrders.Settle;
using PingPayments.PaymentsApi.PaymentOrders.Split;
using PingPayments.PaymentsApi.PaymentOrders.Update;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payments.Get;
using PingPayments.PaymentsApi.Payments.Initiate;
using System;
using System.Net.Http;

namespace PingPayments.PaymentsApi
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
                new GetPaymentOrderEndpoint(httpClient, tenantId),
                new CreatePaymentOrderEndpoint(httpClient, tenantId),
                new UpdatePaymentOrderEndpoint(httpClient, tenantId),
                new ListPaymentOrderEndpoint(httpClient, tenantId),
                new SplitPaymentOrderEndpoint(httpClient, tenantId),
                new ClosePaymentOrderEndpoint(httpClient, tenantId),
                new SettlePaymentOrderEndpoint(httpClient, tenantId)
            );
            Merchants = new MerchantEndpoints
            (
                new CreateMerchantEndpoint(httpClient, tenantId),
                new GetMerchantEndpoint(httpClient, tenantId),
                new ListMerchantsEndpoint(httpClient, tenantId)
            );
        }

        public PaymentEndpoints Payments { get; }
        public PaymentOrderEndpoints PaymentOrder { get; }
        public MerchantEndpoints Merchants { get; }
    }
}
