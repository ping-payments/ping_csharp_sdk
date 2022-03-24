using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public class GetPaymentOrderEndpoint : TenantEndpointBase<Guid, PaymentOrderResponse>
    {
        public GetPaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<PaymentOrderResponse> ExecuteRequest(Guid orderId) => 
            await BaseExecute(GET, $"api/v1/payment_orders/{orderId}");

        protected override async Task<PaymentOrderResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => PaymentOrderResponse.Succesful(hrm.StatusCode, Deserialize<PaymentOrder>(responseBody)),
                _ => PaymentOrderResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}