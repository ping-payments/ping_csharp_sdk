using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{

    public record PaymentResponse : ApiResponseBase<PaymentResponseBody>
    {
        public PaymentResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentResponseBody>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
