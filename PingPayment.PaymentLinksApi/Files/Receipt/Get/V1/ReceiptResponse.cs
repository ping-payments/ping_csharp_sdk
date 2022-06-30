using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Files.Receipt.Get.V1
{
    public record InvoiceResponse : ApiResponseBase<PaymentLink>
    {
        public InvoiceResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentLink>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static InvoiceResponse Succesful(HttpStatusCode statusCode, PaymentLink? b, string rb) => new(statusCode, true, b, rb);
        public static InvoiceResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
