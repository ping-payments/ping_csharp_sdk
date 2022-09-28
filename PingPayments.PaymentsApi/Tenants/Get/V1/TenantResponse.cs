using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Tenants.Get.V1
{
    public record TenantResponse : ApiResponseBase<TenantResponseBody>
    {
        public TenantResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<TenantResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static TenantResponse Succesful(HttpStatusCode statusCode, TenantResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static TenantResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
