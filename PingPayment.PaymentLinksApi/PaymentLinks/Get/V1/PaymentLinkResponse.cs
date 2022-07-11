using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Get.V1
{
    public record PaymentLinkResponse : ApiResponseBase<PaymentLink>
    {
        public PaymentLinkResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentLink>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentLinkResponse Succesful(HttpStatusCode statusCode, PaymentLink? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentLinkResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
