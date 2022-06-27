using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.Tests.V1
{
    public class PaymentLinksTest : BaseResourceTests
    {
        [Fact]
        public async Task List_paymentLink_returns_200()
        {
            var response = await _api.PaymentLinks.V1.List();
            AssertHttpOK(response);
            BasePaymentLinks[]? paymentLinks = response;
            Assert.True(paymentLinks != null);

        }

        [Fact]
        public async Task cancel_paymentLink_returns_200()
        {
            AssertHttpNoContent(await _api.PaymentLinks.V1.Cancel(TestData.PaymentLinkId));
        }
    }
}
