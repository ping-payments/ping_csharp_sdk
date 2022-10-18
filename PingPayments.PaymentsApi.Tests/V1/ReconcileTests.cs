using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class ReconcileTests : BaseResourceTests
    {
        [Fact]
        public async Task Reconcile_payment_204()
        {
            //Create a Payment Order
            var paymentOrderRequest = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
            var paymentorderResponse = await _api.PaymentOrder.V1.Create(paymentOrderRequest);
            Guid paymentOrderid = paymentorderResponse.Body.SuccessfulResponseBody.Id;

            //Create a Payment 
            var paymentRequest = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                }
            ); 
            var paymentResponse = await _api.Payments.V1.Initiate(paymentOrderid ,paymentRequest);
            Guid paymentId = paymentResponse.Body.SuccessfulResponseBody.Id;


            // Reconcile Payment funds 
            var ReconcileOrderItems = new OrderItem[]
            {
                new OrderItem(1.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                new OrderItem(1.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
            };
            var response = await _api.Reconcile.V1.Request(paymentOrderid, paymentId, ReconcileOrderItems);

            AssertHttpNoContent(response);
        }
    }
}
