using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public record PaymentLinksResponse : PaymentLinksApiResponseBase<PaymentLinkList>
    {
        public PaymentLinksResponse(HttpStatusCode StatusCode, bool IsSuccessful, PaymentLinksResponseBody<PaymentLinkList>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static implicit operator PaymentLink[]?(PaymentLinksResponse paymentLinksResponse) =>
            paymentLinksResponse.IsSuccessful &&
            paymentLinksResponse.Body?.SuccessfulResponseBody != null ?
            paymentLinksResponse.Body.SuccessfulResponseBody.PaymentLinks : null;

        public static PaymentLinksResponse Successful(HttpStatusCode statusCode, PaymentLinkList? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentLinksResponse Failure(HttpStatusCode statusCode, PaymentLinksErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
