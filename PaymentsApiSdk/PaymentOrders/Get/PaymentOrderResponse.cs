using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.PaymentOrders.Get
{

    public record PaymentOrderResponse : ApiResponseBase<PaymentOrderResponseBody>
    {
        public PaymentOrderResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderResponseBody>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
