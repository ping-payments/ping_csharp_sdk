using PaymentsApiSdk.PaymentOrders.Shared;
using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.PaymentOrders.List
{
    public record PaymentOrdersResponse : ApiResponseBase<PaymentOrderList>
    {
        public PaymentOrdersResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderList>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}