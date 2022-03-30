using PingPayments.PaymentsApi.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record InitiatePaymentResponse : ApiResponseBase<ProviderMethodResponseBody>
    {
        public InitiatePaymentResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<ProviderMethodResponseBody>? Body, string RawBody) : base(statusCode, IsSuccessful, Body, RawBody) { }
        public static InitiatePaymentResponse Succesful(HttpStatusCode statusCode, ProviderMethodResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static InitiatePaymentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator DummyResponse?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as DummyResponse;
        public static implicit operator SwishMobileResponse?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as SwishMobileResponse;
        public static implicit operator VerifoneResponse?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as VerifoneResponse;
        public static implicit operator PaymentIqResponse?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as PaymentIqResponse;
        public static implicit operator BillmateResponse?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as BillmateResponse;
    }
}
