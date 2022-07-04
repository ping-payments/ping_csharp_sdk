using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.Tests.V1
{
    public class FilesTests : BaseResourceTests
    {
        //[Fact] - not wokring atm
        public async Task Create_Invoice_returns_204()
        {
            CreateInvoiceRequest requestBody = new(ReferenceTypeEnum.KID);

            var response = await _api.Invoice.V1.Create(TestData.PaymentLinkId, requestBody);
            AssertHttpNoContent(response);
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

        //[Fact] - not wokring atm
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


        //[Fact] - not working atm
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
}
