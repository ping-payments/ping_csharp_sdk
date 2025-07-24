using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PingPayments.PaymentsApi.Payments.List.V1
{
    public record PaymentsResponse : ApiResponseBase<PaymentResponseBody[]>
    {
        public PaymentsResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentResponseBody[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentsResponse Successful(HttpStatusCode statusCode, PaymentResponseBody[]? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator PaymentResponseBody[](PaymentsResponse por) =>
            (por?.Body?.SuccessfulResponseBody) ?? new PaymentResponseBody[] { };
    }
}
