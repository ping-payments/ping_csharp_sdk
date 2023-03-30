using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Files.Shared.V1
{
    public record GetInvoiceResponse : PaymentLinksApiResponseBase<GetInvoiceResponseBody>
    {
        public GetInvoiceResponse(HttpStatusCode StatusCode, bool IsSuccessful, PaymentLinksResponseBody<GetInvoiceResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static GetInvoiceResponse Successful(HttpStatusCode statusCode, GetInvoiceResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static GetInvoiceResponse Failure(HttpStatusCode statusCode, PaymentLinksErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
