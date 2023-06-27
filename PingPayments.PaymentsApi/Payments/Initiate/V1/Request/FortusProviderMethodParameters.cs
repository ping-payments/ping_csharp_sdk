using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record FortusProviderMethodParameters
    (
       Invoice InvoiceInformation,
       Address InvoiceAddress,
       Address DeliveryAddress,
       IEnumerable<InvoiceItem>? InvoiceItems = null

    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "invoice", InvoiceInformation },
            { "invoice_address", InvoiceAddress },
            { "delivery_address", DeliveryAddress },
            { "invoice_items", InvoiceItems },
        };
    }
}
