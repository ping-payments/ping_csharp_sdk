using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public class GetEndpoint : TenantEndpointBase<(Guid orderId, Guid paymentId), PaymentResponse>
    {
        public GetEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<PaymentResponse> ExecuteRequest((Guid orderId, Guid paymentId) request) =>
            await BaseExecute(GET, $"api/v1/payment_orders/{request.orderId}/payments/{request.paymentId}");

        protected override async Task<PaymentResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => PaymentResponse.Succesful(hrm.StatusCode, Deserialize<PaymentResponseBody>(responseBody)),
                _ => PaymentResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}
