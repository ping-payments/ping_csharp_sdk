using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.Merchants.Shared
{
    public record MerchantResponse : ApiResponseBase<Merchant>
    {
        public MerchantResponse(int StatusCode, bool IsSuccessful, ResponseBody<Merchant>? Body) : base(StatusCode, IsSuccessful, Body) { }

        public static implicit operator Merchant?(MerchantResponse merchantResponse) =>
            merchantResponse.IsSuccessful &&
            merchantResponse.Body?.SuccesfulResponseBody != null ? 
                merchantResponse.Body.SuccesfulResponseBody : 
                null;
    }
}