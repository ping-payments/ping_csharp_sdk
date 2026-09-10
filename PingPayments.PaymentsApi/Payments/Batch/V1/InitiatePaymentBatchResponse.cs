using PingPayments.Shared;
using System;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.Batch.V1
{
    public record InitiatePaymentBatchResponse : ApiResponseBase<InitiatePaymentBatchResponseBody>
    {
        public InitiatePaymentBatchResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<InitiatePaymentBatchResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody)
        {
        }

        public static implicit operator Guid(InitiatePaymentBatchResponse response) =>
            response.IsSuccessful &&
            response?.Body?.SuccessfulResponseBody != null ?
                response.Body.SuccessfulResponseBody.Id :
                Guid.Empty;

        public static InitiatePaymentBatchResponse Successful(HttpStatusCode statusCode, InitiatePaymentBatchResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static InitiatePaymentBatchResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
