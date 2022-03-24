using PingPayments.PaymentsApi.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public record MerchantResponse : ApiResponseBase<Merchant>
    {
        public MerchantResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Merchant>? Body) : base(StatusCode, IsSuccessful, Body) { }

        public static implicit operator Merchant?(MerchantResponse merchantResponse) =>
            merchantResponse.IsSuccessful &&
            merchantResponse.Body?.SuccesfulResponseBody != null ? 
                merchantResponse.Body.SuccesfulResponseBody : 
                null;
        public static MerchantResponse Succesful(HttpStatusCode statusCode, Merchant? b) => new(statusCode, true, b);
        public static MerchantResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e) => new(statusCode, false, e);

    }
}