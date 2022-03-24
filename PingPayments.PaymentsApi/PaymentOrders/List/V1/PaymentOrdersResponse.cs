using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public record PaymentOrdersResponse : ApiResponseBase<PaymentOrderList>
    {
        public PaymentOrdersResponse(int StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderList>? Body) :
            base(StatusCode, IsSuccessful, Body)
        {

        }
    }
}