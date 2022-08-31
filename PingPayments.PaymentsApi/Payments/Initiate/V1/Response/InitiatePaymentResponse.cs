using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record InitiatePaymentResponse : ApiResponseBase<ProviderMethodResponseBody>
    {
        public InitiatePaymentResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<ProviderMethodResponseBody>? Body, string RawBody) : base(statusCode, IsSuccessful, Body, RawBody) { }
        public static InitiatePaymentResponse Succesful(HttpStatusCode statusCode, ProviderMethodResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static InitiatePaymentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator DummyResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as DummyResponseBody;
        public static implicit operator SwishECommerceResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as SwishECommerceResponseBody;
        public static implicit operator SwishMCommerceResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as SwishMCommerceResponseBody;
        public static implicit operator VerifoneResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as VerifoneResponseBody;
        public static implicit operator PaymentIqResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as PaymentIqResponseBody;
        public static implicit operator BillmateResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as BillmateResponseBody;
        public static implicit operator PingDepositResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as PingDepositResponseBody;
        public static implicit operator BaaseResponseBody?(InitiatePaymentResponse ipr) => ipr?.Body?.SuccesfulResponseBody as BaaseResponseBody;
    }
}
