using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Create.V1
{
    public class CreatePaymentOrderEndpoint : TenantEndpointBase<Guid?, GuidResponse>
    {
        public CreatePaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<GuidResponse> ExecuteRequest(Guid? splitTreeId = null) => 
            await BaseExecute
            (
                POST,
                $"api/v1/payment_orders",
                splitTreeId.HasValue ? ToJson(new { split_tree_id = splitTreeId.Value }) : ToJson(new { })
            );

        protected override async Task<GuidResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => GuidResponse.Succesful(hrm.StatusCode, Deserialize<GuidResponseBody>(responseBody)),
                _ => GuidResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}