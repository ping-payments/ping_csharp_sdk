using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Merchant.V1.AIS.Response
{
    public record AisMerchantResponse : ApiResponseBase<AisMerchantResponseBody>
    {
        public AisMerchantResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<AisMerchantResponseBody> body, string rawBody) : base(StatusCode, IsSuccessful, body, rawBody) { }
        public static AisMerchantResponse Successful(HttpStatusCode statusCode, AisMerchantResponseBody body, string rawBody) => new(statusCode, true, body, rawBody);
        public static AisMerchantResponse Failure(HttpStatusCode statusCode, ErrorResponseBody error, string rawBody) => new(statusCode, false, error, rawBody);

    }
}
