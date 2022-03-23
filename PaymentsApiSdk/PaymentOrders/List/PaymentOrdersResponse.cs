using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.PaymentOrders.List
{
    public record PaymentOrdersResponse : ApiResponseBase<PaymentOrdersResponseBody>
    {
        public PaymentOrdersResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrdersResponseBody>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}