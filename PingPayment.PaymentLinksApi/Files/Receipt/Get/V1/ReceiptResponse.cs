using PingPayments.PaymentLinksApi.Files.Shared;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Files.Receipt.Get.V1
{
    public record ReceiptResponse : ApiResponseBase<UrlResponseBody>
    {
        public ReceiptResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<UrlResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ReceiptResponse Succesful(HttpStatusCode statusCode, UrlResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static ReceiptResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
