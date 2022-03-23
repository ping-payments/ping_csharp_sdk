using PaymentsApiSdk.PaymentOrders.Shared;
using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.PaymentOrders.Get
{
    public record PaymentOrderResponse : ApiResponseBase<PaymentOrder>
    {
        public PaymentOrderResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrder>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
