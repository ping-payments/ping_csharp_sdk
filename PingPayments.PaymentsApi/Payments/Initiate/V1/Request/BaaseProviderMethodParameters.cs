using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record BaaseProviderMethodParameters(BaaseInvoiceInformation? invoiceInformation = null) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() =>
            invoiceInformation switch
            {
                null => new Dictionary<string, dynamic>(),
                _ => new() { { "invoice_information", invoiceInformation.ToDictionary() } }
            };
    }
}
