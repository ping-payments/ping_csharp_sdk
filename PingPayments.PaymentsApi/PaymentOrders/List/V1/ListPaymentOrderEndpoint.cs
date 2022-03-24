using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.List.V1
{
    public class ListPaymentOrderEndpoint : TenantEndpointBase<(DateTimeOffset from, DateTimeOffset to)?, PaymentOrdersResponse>
    {
        public ListPaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        public override async Task<PaymentOrdersResponse> ExecuteRequest((DateTimeOffset from, DateTimeOffset to)? dateFilters) => 
            await BaseExecute
            (
                GET,
                dateFilters.HasValue ?
                    $"api/v1/payment_orders?from={dateFilters.Value.from:O}&to={dateFilters.Value.to:O}" :
                    $"api/v1/payment_orders"
            );

        protected override async Task<PaymentOrdersResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var response = hrm.StatusCode switch
            {
                OK => PaymentOrdersResponse.Succesful(hrm.StatusCode, new PaymentOrderList(Deserialize<PaymentOrder[]>(responseBody))),
                _ => PaymentOrdersResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return response;
        }
    }
}