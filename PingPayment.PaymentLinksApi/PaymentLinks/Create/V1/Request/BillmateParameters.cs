namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record BillmateParameters
        (
            string FirstName,
            string LastName,
            string NattionalIdNumber,
            string Email,
            string PhoneNumber,
            string Country,
            string IpAddress,
            string CustomerReference,
            string IsCompanyCustomer,
            string? CareOf,
            string? FreeText

        ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "first_name", FirstName },
            { "care_of", CareOf ?? string.Empty },
            { "last_name", LastName },
            { "national_id_number", NattionalIdNumber },
            { "email", Email },
            { "phone_number", PhoneNumber },
            { "country", Country },
            { "ip_address", IpAddress },
            { "customer_reference", CustomerReference },
            { "is_company_customer", IsCompanyCustomer },
            { "free_text", FreeText?? string.Empty },
        };
    }
}