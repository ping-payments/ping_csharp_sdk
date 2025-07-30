using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public record MerchantsPageResponse : ApiResponseBase<GenericTransfer<Merchant>>
    {
        public MerchantsPageResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenericTransfer<Merchant>>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static MerchantsPageResponse Successful(HttpStatusCode statusCode, GenericTransfer<Merchant>? b, string rb) => new(statusCode, true, b, rb);
        public static MerchantsPageResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator GenericTransfer<Merchant>(MerchantsPageResponse mr) =>
            (mr?.Body?.SuccessfulResponseBody) ?? new GenericTransfer<Merchant> { };

        public static implicit operator Merchant[](MerchantsPageResponse mr) =>
            (mr?.Body?.SuccessfulResponseBody?.Data) ?? new Merchant[] { };

        public static implicit operator PaginationLinks(MerchantsPageResponse mr) =>
            (mr?.Body?.SuccessfulResponseBody?.PaginationLinks) ?? new PaginationLinks { };

    }
}