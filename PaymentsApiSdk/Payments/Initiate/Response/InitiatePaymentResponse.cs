using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.Payments.Initiate.Response
{
    public record InitiatePaymentResponse : ApiResponseBase<InitiatePaymentResponseBody>
    {
        public InitiatePaymentResponse(int StatusCode, bool IsSuccessful, ResponseBody<InitiatePaymentResponseBody>? Body) : 
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
