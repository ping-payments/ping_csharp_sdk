﻿using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;

namespace PingPayments.PaymentLinksApi.Tests.V1;

public class FilesTests : BaseResourceTests
{
    //[Fact] - "No matching deposit account was found"
    public async Task Create_Invoice_with_reference_KID_returns_204()
    {
        CreateInvoiceRequest requestBody = new(ReferenceTypeEnum.KID);
        var response = await _api.Invoice.V1.Create(TestData.PaymentLinkId, requestBody);
        AssertHttpNoContent(response);
    }

    public async Task Create_Invoice_with_reference_OCR_returns_204()
    {
        CreateInvoiceRequest requestBody = new(ReferenceTypeEnum.OCR);
        var response = await _api.Invoice.V1.Create(TestData.PaymentLinkId, requestBody);
        AssertHttpNoContent(response);
    }

    //[Fact]- "No matching deposit account was found"
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

    //[Fact] - No invoice to fetch yet.
    public async Task Get_invoice_returns_200()
    {
        // add a paymentlink with an invoice
        AssertHttpOK(await _api.Invoice.V1.Get(TestData.PaymentLinkId));
    }
    [Fact]
    public async Task Get_invoice_from_paymentLink_with_no_invoice_returns_403()
    {
        AssertHttpApiError(await _api.Invoice.V1.Get(TestData.PaymentLinkId));
    }

    [Fact]
    public async Task Get_invoice_paymentLink_not_found_returns_404()
    {
        AssertHttpNotFound(await _api.Invoice.V1.Get(new Guid()));
    }


    //[Fact] - not receipt to fetch yet
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
}
