using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;

namespace PingPayments.PaymentLinksApi.Tests.V1
{
    public class PaymentLinksTest : BaseResourceTests
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
            AssertHttpNoContent(await _api.PaymentLinks.V1.Cancel(new Guid(paymentlink.Body?.SuccesfulResponseBody?.Id.ToString())));
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
            var customer = new Customer("FrstName", "LastName");
            var items = new Item[]
            {
                new Item("Hawaii Pizza", TestData.MerchantId, 7000, 2, SwedishVat.Vat12)
            };
            var dueDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            var suppler = new Supplier("Supllier name");
            
            var swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
            var Verifone = CreatePaymentProviderMethod.Verifone.Card();
            var billmate = CreatePaymentProviderMethod.Billmate.Invoice();

            var paymentLinkRequest = new CreatePaymentLinkRequest
                (
                    TestData.OrderId,
                    CurrencyEnum.SEK,
                    customer,
                    dueDate,
                    Locale.Swedish,
                    items,
                    suppler,
                    new PaymentProviderMethod[]
                    {
                        swishMcommmerce,
                        Verifone,
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
            var customer = new Customer("FrstName", "LastName");
            var items = new Item[]
            {
                new Item("Hawaii Pizza", TestData.MerchantId, 7000, 2, SwedishVat.Vat12)
            };
            var dueDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            var suppler = new Supplier("Supllier name");

            var swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
            var Verifone = CreatePaymentProviderMethod.Verifone.Card();
            var billmate = CreatePaymentProviderMethod.Billmate.Invoice();

            var paymentLinkRequest = new CreatePaymentLinkRequest
                (
                    TestData.OrderId,
                    CurrencyEnum.NOK,
                    customer,
                    dueDate,
                    Locale.Swedish,
                    items,
                    suppler,
                    new PaymentProviderMethod[]
                    {
                        swishMcommmerce,
                        Verifone,
                        billmate,
                    }
                );

            var response = await _api.PaymentLinks.V1.Create(paymentLinkRequest);
            AssertHttpUnprocessableEntity(response);
        }

        [Fact]
        public async Task Create_paymentLink_without_paymentProvider_returns_403()
        {
            var customer = new Customer("FrstName", "LastName");
            var items = new Item[]
            {
                new Item("Hawaii Pizza", TestData.MerchantId, 7000, 2, SwedishVat.Vat12)
            };
            var dueDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            var suppler = new Supplier("Supllier name");

            var _swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
            var _Verifone = CreatePaymentProviderMethod.Verifone.Card();
            var _billmate = CreatePaymentProviderMethod.Billmate.Invoice();

            var paymentLinkRequest = new CreatePaymentLinkRequest
                (
                    TestData.OrderId,
                    CurrencyEnum.SEK,
                    customer,
                    dueDate,
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
