using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PingPayments.PaymentsApi.Payments.List.V1
{
    public record PaymentsDataResponse : ApiResponseBase<PaymentResponseBody[]>
    {
        public PaymentsDataResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentResponseBody[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentsDataResponse Successful(HttpStatusCode statusCode, PaymentResponseBody[]? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentsDataResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator PaymentResponseBody[](PaymentsDataResponse por) =>
            (por?.Body?.SuccessfulResponseBody) ?? new PaymentResponseBody[] { };
    }
}
