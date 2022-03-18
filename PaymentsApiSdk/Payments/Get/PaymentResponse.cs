using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.Payments.Get
{

    public record PaymentResponse : ApiResponseBase<PaymentResponseBody>
    {
        public PaymentResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentResponseBody>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
