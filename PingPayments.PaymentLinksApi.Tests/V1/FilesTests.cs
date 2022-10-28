using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;

namespace PingPayments.PaymentLinksApi.Tests.V1;

public class FilesTests : BaseResourceTests
{
    [Fact]
    public async Task Create_Invoice_returns_204()
    {

        Guid paymentLinkId = await CreatePaymentLinkInNewPaymentOrder();

        // Create an Invoice
        CreateInvoiceRequest requestBody = new(ReferenceTypeEnum.OCR);
        var response = await _api.Invoice.V1.Create(paymentLinkId, requestBody);
        AssertHttpNoContent(response);
    }

    [Fact]
    public async Task Create_Invoice_already_exists_returns_403()
    {
        CreateInvoiceRequest requestBody = new(ReferenceTypeEnum.OCR);
        var response = await _api.Invoice.V1.Create(TestData.PaymentLinkId, requestBody);
        AssertHttpApiError(response);
    }

    [Fact]
    public async Task Create_Invoice_empty_body_returns_422()
    {
        AssertHttpUnprocessableEntity(await _api.Invoice.V1.Create(TestData.PaymentLinkId, null));
    }

    [Fact]
    public async Task Create_Invoice_paymentLink_not_found_returns_404()
    {
        CreateInvoiceRequest requestBody = new(ReferenceTypeEnum.KID);
        AssertHttpNotFound(await _api.Invoice.V1.Create(new Guid(), requestBody));
    }

    [Fact]
    public async Task Get_invoice_returns_200()
    {
        AssertHttpOK(await _api.Invoice.V1.Get(TestData.PaymentLinkId));
    }
    [Fact]
    public async Task Get_invoice_from_paymentLink_with_no_invoice_returns_403()
    {
        Guid paymentlinkId = await CreatePaymentLinkInNewPaymentOrder();
        AssertHttpApiError(await _api.Invoice.V1.Get(paymentlinkId));
    }

    [Fact]
    public async Task Get_invoice_paymentLink_not_found_returns_404()
    {
        AssertHttpNotFound(await _api.Invoice.V1.Get(new Guid()));
    }

    [Fact]
    public async Task Get_receipt_returns_200()
    {
        AssertHttpOK(await _api.Receipt.V1.Get(TestData.PaymentLinkId));
    }

    [Fact]
    public async Task Get_receipt_from_unpayed_paymentLink_returns_403()
    {
        AssertHttpApiError(await _api.Receipt.V1.Get(TestData.PaymentLinkId));
    }

    [Fact]
    public async Task Get_receipts_paymentLink_not_found_returns_404()
    {
        AssertHttpNotFound(await _api.Receipt.V1.Get(new Guid()));
    }
    public async Task<Guid> CreatePaymentLinkInNewPaymentOrder()
    {
        //Create a paymentOrder
        var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
        var paymentOrderResponse = await _paymentsApi.PaymentOrder.V1.Create(request);
        Guid paymentOrderId = paymentOrderResponse.Body.SuccessfulResponseBody.Id;

        // Create a PaymentLink
        var customer = new Customer("FrstName", "LastName");
        var items = new Item[]
        {
                new Item("Hawaii Pizza", TestData.MerchantId, 70.ToMinorCurrencyUnit(), 2, SwedishVat.Vat12)
        };
        var dueDate = DateTimeOffset.Now.AddDays(30).ToString("yyyy-MM-dd");
        var suppler = new Supplier("Supllier name");
        var invoiceAdress = new Adress("Örebro", "Signalgatan 7", "70216");
        var swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
        var Verifone = CreatePaymentProviderMethod.Verifone.Card();
        var billmate = CreatePaymentProviderMethod.Billmate.Invoice();

        var paymentLinkRequest = new CreatePaymentLinkRequest
            (
                paymentOrderId,
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
                },
                invoiceAdress: invoiceAdress
            );
        var paymentLinkResponse = await _api.PaymentLinks.V1.Create(paymentLinkRequest);
        return paymentLinkResponse.Body.SuccessfulResponseBody.Id;
    }
}
