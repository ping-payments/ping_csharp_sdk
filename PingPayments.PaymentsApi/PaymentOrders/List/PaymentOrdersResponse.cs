using PingPayments.PaymentsApi.PaymentOrders.Shared;
using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.List
{
    public record PaymentOrdersResponse : ApiResponseBase<PaymentOrderList>
    {
        public PaymentOrdersResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderList>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}