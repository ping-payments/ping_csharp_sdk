using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1
{
    public record CreatePaymentLinkResponse : ApiResponseBase<CreatePaymentLinkResponseBody>
    {
        public CreatePaymentLinkResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<CreatePaymentLinkResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody){}
        public static CreatePaymentLinkResponse Succesful(HttpStatusCode statusCode, CreatePaymentLinkResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static CreatePaymentLinkResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
