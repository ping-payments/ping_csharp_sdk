
namespace PaymentsApiSDK.Interfaces
{
    public interface IVerifoneProviderMetaData
    {
        string CancelUrl { get; init; }
        string Email { get; init; }
        string FirstName { get; init; }
        string LastName { get; init; }
        string SuccessUrl { get; init; }
    }
}