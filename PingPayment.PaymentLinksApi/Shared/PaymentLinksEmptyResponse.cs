using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Shared
{
    public record PaymentLinksEmptyResponse : PaymentLinksApiResponseBase<EmptySuccessfulResponseBody>
    {
        public PaymentLinksEmptyResponse(HttpStatusCode StatusCode, bool IsSuccessful, PaymentLinksResponseBody<EmptySuccessfulResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentLinksEmptyResponse Empty(HttpStatusCode statusCode, bool isSuccessful) => new(statusCode, isSuccessful, EmptySuccessfulResponseBody.Empty, string.Empty);
        public static PaymentLinksEmptyResponse Successful(HttpStatusCode statusCode) => Empty(statusCode, true);
        public static PaymentLinksEmptyResponse Failure(HttpStatusCode statusCode, PaymentLinksErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
