using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record BaaseProviderMethodParameters(BaaseInvoiceInformation? invoiceInformation = null) : ProviderMethodParameters
    {

        Dictionary<string, dynamic> invoiceInformationDict() => invoiceInformation?.ToDictionary() ?? new Dictionary<string, dynamic>();

        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "invoice_information", invoiceInformationDict()}
        };

    }
}