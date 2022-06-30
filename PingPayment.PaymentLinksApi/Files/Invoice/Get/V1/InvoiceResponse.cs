using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Get.V1
{
    public record InvoiceResponse : ApiResponseBase<InvoiceResponseBody>
    {
        public InvoiceResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<InvoiceResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static InvoiceResponse Succesful(HttpStatusCode statusCode, InvoiceResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static InvoiceResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
