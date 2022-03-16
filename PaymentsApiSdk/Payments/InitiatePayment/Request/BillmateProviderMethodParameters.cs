using System.Collections.Generic;

namespace PaymentsApiSdk.Payments.InitiatePayment.Request
{
    public record BillmateProviderMethodParameters
    (
        string FirstName,
        string LastName,
        string NattionalIdNumber,
        string Email,
        string PhoneNumber,
        string Country,
        string IpAddress,
        string CustomerReference,
        bool IsCompanyCustomer
    ) : ProviderMethodParameters
    {
        public override Dictionary<string, dynamic> ToDictionary() => new()
        {
            { "first_name", FirstName },
            { "care_of", string.Empty },
            { "last_name", LastName },
            { "national_id_number", NattionalIdNumber },
            { "email", Email },
            { "phone_number", PhoneNumber },
            { "country", Country },
            { "ip_address", IpAddress },
            { "customer_reference", CustomerReference },
            { "is_company_customer", IsCompanyCustomer },
            { "free_text", string.Empty },
        };
    }
}
