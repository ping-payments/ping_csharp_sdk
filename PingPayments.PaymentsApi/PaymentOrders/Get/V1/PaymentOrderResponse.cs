using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public record PaymentOrderResponse : ApiResponseBase<PaymentOrder>
    {
        public PaymentOrderResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrder>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}
