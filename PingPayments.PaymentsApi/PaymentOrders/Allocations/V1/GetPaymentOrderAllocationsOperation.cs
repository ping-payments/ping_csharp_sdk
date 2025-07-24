using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Allocations.V1
{

    public class GetPaymentOrderAllocationsOperation : OperationBase<Guid, AllocationsResponse>
    {
        public GetPaymentOrderAllocationsOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<AllocationsResponse> ExecuteRequest(Guid orderId) =>
            await BaseExecute(GET, $"api/v1/payment_orders/{orderId}/allocations", orderId);

        protected override async Task<AllocationsResponse> ParseHttpResponse(HttpResponseMessage httpResponse, Guid request)
        {
            var responseBody = await httpResponse.Content.ReadAsStringAsyncMemoized();

            var response = httpResponse.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => AllocationsResponse.Failure(httpResponse.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };

            async Task<AllocationsResponse> GetSuccessful()
            {
                var allocations = await Deserialize<Allocation[]>(responseBody);
                return AllocationsResponse.Successful(httpResponse.StatusCode, allocations, responseBody);
            }

            return response;
        }
    }
}
