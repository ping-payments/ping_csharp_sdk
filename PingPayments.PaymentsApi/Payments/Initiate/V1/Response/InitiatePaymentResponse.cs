using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record InitiatePaymentResponse : ApiResponseBase<InitiatePaymentResponseBody>
    {
        public InitiatePaymentResponse(int StatusCode, bool IsSuccessful, ResponseBody<InitiatePaymentResponseBody>? Body) : 
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
