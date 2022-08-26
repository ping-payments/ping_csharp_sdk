using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record BaaseInvoiceInformation
    (
        string County,
        string FirstName,
        string LastName,
        string PostalCode,
        string StreetAddress,
        string? InvoiceLogoUrl = null
    )
    {
        public Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "county", County },
            { "first_name", FirstName },
            { "invoice_logo_url", InvoiceLogoUrl ?? string.Empty },
            { "last_name", LastName },
            { "postal_code", PostalCode },
            { "street_address", StreetAddress },
        };
    }
}
