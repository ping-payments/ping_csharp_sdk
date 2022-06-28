using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
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
        public async Task GetPaymentLinkReturns200()
        {
            var response = await _api.PaymentLinks.V1.Get(TestData.PaymentLinkId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_paymentLink_Id_Not_Found_Returns_404()
        {
            var response = await _api.PaymentLinks.V1.Get(new Guid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Cancel_paymentLink_returns_204()
        {
            /// Create paymentlink here and use that id in this test
            AssertHttpNoContent(await _api.PaymentLinks.V1.Cancel(TestData.PaymentLinkId));
        }

        [Fact]
        public async Task Cancel_paymentLink_Id_Not_Found_returns_404()
        {
            AssertHttpNotFound(await _api.PaymentLinks.V1.Cancel(new Guid()));
        }

        [Fact]
        public async Task PaymentLink_Already_Canceled_returns_403()
        {
            AssertHttpApiError(await _api.PaymentLinks.V1.Cancel(TestData.PaymentLinkId));
        }

        [Fact]
        public async Task Send_paymentLink_returns_204()
        {
            var requestObject = DistributeMethod.SmsAndEmail.New(
                    "0731231212",
                    "some.mail@mail.com"
                );


            var response = await _api.PaymentLinks.V1.Send(new Guid("498989e0-2cd3-4687-83b1-f6d728ad8f06"), requestObject);
            AssertHttpNoContent(response);
        }
    }
}
