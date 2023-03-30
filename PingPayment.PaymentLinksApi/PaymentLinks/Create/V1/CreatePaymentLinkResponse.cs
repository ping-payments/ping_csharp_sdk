using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1
{
    public record CreatePaymentLinkResponse : PaymentLinksApiResponseBase<CreatePaymentLinkResponseBody>
    {
        public CreatePaymentLinkResponse(HttpStatusCode StatusCode, bool IsSuccessful, PaymentLinksResponseBody<CreatePaymentLinkResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static CreatePaymentLinkResponse Successful(HttpStatusCode statusCode, CreatePaymentLinkResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static CreatePaymentLinkResponse Failure(HttpStatusCode statusCode, PaymentLinksErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
