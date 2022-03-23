using PaymentsApiSdk.Merchants.Shared;
using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.Merchants.List
{
    public record MerchantsResponse : ApiResponseBase<MerchantList>
    {
        public MerchantsResponse(int StatusCode, bool IsSuccessful, ResponseBody<MerchantList>? Body) : base(StatusCode, IsSuccessful, Body) { }

        public static implicit operator Merchant[]?(MerchantsResponse merchantResponse) =>
            merchantResponse.IsSuccessful &&
            merchantResponse.Body?.SuccesfulResponseBody != null ?
                merchantResponse.Body.SuccesfulResponseBody.Merchants :
                null;
    }
}