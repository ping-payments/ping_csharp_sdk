using PaymentsApiSdk.PaymentOrders;
using PaymentsApiSdk.PaymentOrders.Close;
using PaymentsApiSdk.PaymentOrders.Create;
using PaymentsApiSdk.PaymentOrders.Get;
using PaymentsApiSdk.PaymentOrders.List;
using PaymentsApiSdk.PaymentOrders.Settle;
using PaymentsApiSdk.PaymentOrders.Split;
using PaymentsApiSdk.PaymentOrders.Update;
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
                new GetPaymentOrderEndpoint(httpClient, tenantId),
                new CreatePaymentOrderEndpoint(httpClient, tenantId),
                new UpdatePaymentOrderEndpoint(httpClient, tenantId),
                new ListPaymentOrderEndpoint(httpClient, tenantId),
                new SplitPaymentOrderEndpoint(httpClient, tenantId),
                new ClosePaymentOrderEndpoint(httpClient, tenantId),
                new SettlePaymentOrderEndpoint(httpClient, tenantId)

            );
        }

        public PaymentEndpoints Payments { get; }
        public PaymentOrderEndpoints PaymentOrder { get; }
    }
}
