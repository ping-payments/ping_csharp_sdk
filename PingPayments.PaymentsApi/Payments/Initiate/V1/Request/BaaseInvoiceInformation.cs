using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record BaaseInvoiceInformation
    (
        string County,
        string FirstName,
        string LastName,
        string postalCode,
        string streetAddress,
        string? invoiceLogoUrl = null
    )
    {
        public Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "county", County },
            { "first_name", FirstName },
            { "invoice_logo_url", invoiceLogoUrl ?? string.Empty},
            { "last_name", LastName },
            { "postal_code", postalCode },
            { "street_address", streetAddress },
        };
    }
}
