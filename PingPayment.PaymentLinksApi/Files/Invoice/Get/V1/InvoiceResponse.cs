using PingPayments.PaymentLinksApi.Files.Shared;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Get.V1
{
    public record InvoiceResponse : ApiResponseBase<UrlResponseBody>
    {
        public InvoiceResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<UrlResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static InvoiceResponse Succesful(HttpStatusCode statusCode, UrlResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static InvoiceResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
