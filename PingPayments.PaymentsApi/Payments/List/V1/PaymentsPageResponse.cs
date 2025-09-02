using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PingPayments.PaymentsApi.Payments.List.V1
{
    public record PaymentsPageResponse : ApiResponseBase<GenericTransfer<Payment>>
    {
        public PaymentsPageResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenericTransfer<Payment>>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentsPageResponse Successful(HttpStatusCode statusCode, GenericTransfer<Payment>? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentsPageResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator GenericTransfer<Payment>(PaymentsPageResponse pr) =>
            (pr?.Body?.SuccessfulResponseBody) ?? new GenericTransfer<Payment> { };

        public static implicit operator Payment[](PaymentsPageResponse pr) =>
            (pr?.Body?.SuccessfulResponseBody?.Data) ?? new Payment[] { };

        public static implicit operator PaginationLinks(PaymentsPageResponse pr) =>
            (pr?.Body?.SuccessfulResponseBody?.PaginationLinks) ?? new PaginationLinks { };
    }
}
