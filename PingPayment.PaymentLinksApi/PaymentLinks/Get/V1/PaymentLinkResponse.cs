using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Get.V1
{
    public record PaymentLinkResponse : ApiResponseBase<BasePaymentLinks>
    {
        public PaymentLinkResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<BasePaymentLinks>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentLinkResponse Succesful(HttpStatusCode statusCode, BasePaymentLinks? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentLinkResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
