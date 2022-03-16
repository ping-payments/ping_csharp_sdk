using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.Payments.InitiatePayment.Response
{
    public record InitiatePaymentResponse : ApiResponseBase<InitiatePaymentResponseBody>
    {
        public InitiatePaymentResponse(int StatusCode, bool IsSuccessful, ResponseBody<InitiatePaymentResponseBody>? Body) : 
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
