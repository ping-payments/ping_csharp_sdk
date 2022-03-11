namespace PaymentsApiSDK.Interfaces
{
    public interface ISwishProviderMetaData
    {
        string Message { get; init; }
        string PhoneNumber { get; init; }
    }
}