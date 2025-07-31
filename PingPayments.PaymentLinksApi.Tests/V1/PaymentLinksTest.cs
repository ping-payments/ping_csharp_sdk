using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using PingPayments.Tests;

namespace PingPayments.PaymentLinksApi.Tests.V1
{
    public class PaymentLinksTest : PaymentLinksApiTestClient
    {
        [Fact]
        public async Task List_paymentLink_returns_200()
        {
            var response = await _api.PaymentLinks.V1.List();
            AssertHttpOK(response);
            PaymentLink[]? paymentLinks = response;
            Assert.True(paymentLinks != null);
        }

        [Fact]
        public async Task GetPaymentLinkReturns200()
        {
            AssertHttpOK(await _api.PaymentLinks.V1.Get(TestData.PaymentLinkId));
        }

        [Fact]
        public async Task Get_paymentLink_Id_Not_Found_Returns_404()
        {
            AssertHttpNotFound(await _api.PaymentLinks.V1.Get(new Guid()));
        }

        [Fact]
        public async Task Cancel_paymentLink_returns_204()
        {
            var paymentlink = await Create_paymentLink_returns_200();
            AssertHttpNoContent(await _api.PaymentLinks.V1.Cancel(new Guid(paymentlink.Body?.SuccessfulResponseBody?.Id.ToString())));
        }

        [Fact]
        public async Task Cancel_paymentLink_Id_Not_Found_returns_404()
        {
            AssertHttpNotFound(await _api.PaymentLinks.V1.Cancel(new Guid()));
        }

        [Fact]
        public async Task PaymentLink_Already_Canceled_returns_403()
        {
            var paymentLinkResponse = Create_paymentLink_returns_200();
            Guid paymentLinkId = paymentLinkResponse.Result.Body.SuccessfulResponseBody.Id;
            await _api.PaymentLinks.V1.Cancel(paymentLinkId);

            AssertHttpApiError(await _api.PaymentLinks.V1.Cancel(paymentLinkId));
        }

        [Fact]
        public async Task Send_paymentLink_with_sms_and_email_returns_204()
        {
            var requestObject = DistributeMethod.SmsAndEmail.New(
                    "0731231212",
                    "some.mail@mail.com"
                );
            var response = await _api.PaymentLinks.V1.Send(TestData.PaymentLinkId, requestObject);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Send_paymentLink_with_sms_returns_204()
        {
            var requestObject = DistributeMethod.Sms.New(
                    "0731231212"
                );
            var response = await _api.PaymentLinks.V1.Send(TestData.PaymentLinkId, requestObject);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Send_paymentLink_with_email_returns_204()
        {
            var requestObject = DistributeMethod.Email.New(
                    "some.mail@mail.com"
                );
            var response = await _api.PaymentLinks.V1.Send(TestData.PaymentLinkId, requestObject);
            AssertHttpNoContent(response);
        }


        [Fact]
        public async Task Send_paymentLink_Id_Not_Found_returns_404()
        {
            var requestObject = DistributeMethod.SmsAndEmail.New(
                    "0731231212",
                    "some.mail@mail.com"
                );
            var response = await _api.PaymentLinks.V1.Send(new Guid(), requestObject);
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Send_paymentLink_incorrect_body_returns_422()
        {
            AssertHttpUnprocessableEntity(await _api.PaymentLinks.V1.Send(TestData.PaymentLinkId, null));
        }

        [Fact]
        public async Task<CreatePaymentLinkResponse> Create_paymentLink_returns_200()
        {
            var paymentOrderRequest = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
            var paymentOrderResponose = await _paymentsApi.PaymentOrder.V1.Create(paymentOrderRequest);
            var orderId = paymentOrderResponose.Body.SuccessfulResponseBody.Id;

            var customer = new Customer("FirstName", "LastName");
            var tags = new string[] { "test1", "test2" };
            var items = new Item[]
            {
                new Item(
                    description:"Hawaii Pizza",
                    merchantId: TestData.MerchantId,
                    price: 70.ToMinorCurrencyUnit(),
                    quantity: 2,
                    vat: SwedishVat.Vat12,
                    metadata: new Dictionary<string, dynamic>(){ {"meta", "data"} },
                    tags: tags)
            };
            var suppler = new Supplier("Supplier name");

            var swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
            var billmate = CreatePaymentProviderMethod.Billmate.Invoice();

            var paymentLinkRequest = new CreatePaymentLinkRequest
                (
                    orderId,
                    CurrencyEnum.SEK,
                    customer,
                    Locale.Swedish,
                    items,
                    suppler,
                    new PaymentProviderMethod[]
                    {
                        swishMcommmerce,
                        billmate,
                    }
                );

            var response = await _api.PaymentLinks.V1.Create(paymentLinkRequest);

            AssertHttpOK(response);
            return response;
        }

        [Fact]
        public async Task Create_paymentLink_with_wrong_currency_returns_422()
        {
            var customer = new Customer("FirstName", "LastName");
            var items = new Item[]
            {
                new Item("Hawaii Pizza", TestData.MerchantId, 70.ToMinorCurrencyUnit(), 2, SwedishVat.Vat12)
            };

            var suppler = new Supplier("Supplier name");

            var swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
            var billmate = CreatePaymentProviderMethod.Billmate.Invoice();

            var paymentLinkRequest = new CreatePaymentLinkRequest
                (
                    TestData.OrderId,
                    CurrencyEnum.NOK,
                    customer,
                    Locale.Swedish,
                    items,
                    suppler,
                    new PaymentProviderMethod[]
                    {
                        swishMcommmerce,
                        billmate,
                    }
                );

            var response = await _api.PaymentLinks.V1.Create(paymentLinkRequest);
            AssertHttpUnprocessableEntity(response);
        }

        [Fact]
        public async Task Create_paymentLink_without_paymentProvider_returns_403()
        {
            var customer = new Customer("FirstName", "LastName");
            var items = new Item[]
            {
                new Item("Hawaii Pizza", TestData.MerchantId, 70.ToMinorCurrencyUnit(), 2, SwedishVat.Vat12)
            };
            var suppler = new Supplier("Supplier name");

            var paymentLinkRequest = new CreatePaymentLinkRequest
                (
                    TestData.OrderId,
                    CurrencyEnum.SEK,
                    customer,
                    Locale.Swedish,
                    items,
                    suppler,
                    new PaymentProviderMethod[]
                    {
                    }
                );

            var response = await _api.PaymentLinks.V1.Create(paymentLinkRequest);
            AssertHttpApiError(response);
        }
    }
}
