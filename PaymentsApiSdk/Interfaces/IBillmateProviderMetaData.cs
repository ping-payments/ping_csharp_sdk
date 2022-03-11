namespace PaymentsApiSDK.Interfaces
{
    public interface IBillmateProviderMetaData : IProviderMetaData
    {
        string Country { get; init; }
        string CustomerReference { get; init; }
        string Email { get; init; }
        string FirstName { get; init; }
        string IpAddress { get; init; }
        bool IsCompanyCustomer { get; init; }
        string LastName { get; init; }
        string NattionalIdNumber { get; init; }
        string PhoneNumber { get; init; }       
    }
}