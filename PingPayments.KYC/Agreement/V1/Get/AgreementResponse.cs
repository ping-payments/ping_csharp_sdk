using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Agreement.V1.Get
{
    public record AgreementResponse : ApiResponseBase<AgreementResponseBody>
    {
        public AgreementResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<AgreementResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static AgreementResponse Successful(HttpStatusCode statusCode, AgreementResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static AgreementResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
