using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PingPayments.PaymentsApi.Payments.List.V1
{
    public record PaymentsPageResponse : ApiResponseBase<GenericTransfer<PaymentResponseBody>>
    {
        public PaymentsPageResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenericTransfer<PaymentResponseBody>>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentsPageResponse Successful(HttpStatusCode statusCode, GenericTransfer<PaymentResponseBody>? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentsPageResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator GenericTransfer<PaymentResponseBody>(PaymentsPageResponse pr) =>
            (pr?.Body?.SuccessfulResponseBody) ?? new GenericTransfer<PaymentResponseBody> { };

        public static implicit operator PaymentResponseBody[](PaymentsPageResponse pr) =>
            (pr?.Body?.SuccessfulResponseBody?.Data) ?? new PaymentResponseBody[] { };

        public static implicit operator PaginationLinks(PaymentsPageResponse pr) =>
            (pr?.Body?.SuccessfulResponseBody?.PaginationLinks) ?? new PaginationLinks { };
    }
}
