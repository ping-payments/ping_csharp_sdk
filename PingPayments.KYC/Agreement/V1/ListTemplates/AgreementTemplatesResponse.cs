using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Agreement.V1.GetAgreementTemplates
{
    public record AgreementTemplatesResponse : ApiResponseBase<AgreementTemplate[]>
    {
        public AgreementTemplatesResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<AgreementTemplate[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static implicit operator AgreementTemplate[]?(AgreementTemplatesResponse merchantResponse) =>
            merchantResponse.IsSuccessful && merchantResponse.Body?.SuccessfulResponseBody != null
                ? merchantResponse.Body.SuccessfulResponseBody
                : null;

        public static AgreementTemplatesResponse Successful(HttpStatusCode statusCode, AgreementTemplate[]? b, string rb) => 
            new(statusCode, true, b, rb);

        public static AgreementTemplatesResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => 
            new(statusCode, false, e, rb);
    }
}
