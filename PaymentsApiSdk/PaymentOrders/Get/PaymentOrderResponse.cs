using PingPayments.PaymentsApi.PaymentOrders.Shared;
using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.Get
{
    public record PaymentOrderResponse : ApiResponseBase<PaymentOrder>
    {
        public PaymentOrderResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrder>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
