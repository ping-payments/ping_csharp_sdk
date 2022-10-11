using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Text;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;

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
                OK => await GetSuccesful(),
                _ => AllocationsResponse.Failure(httpResponse.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };

            async Task<AllocationsResponse> GetSuccesful()
            {
                var allocations = await Deserialize<Allocation[]>(responseBody);
                var allocationList = allocations == null ? null : new AllocationList(allocations);

                return AllocationsResponse.Succesful(httpResponse.StatusCode, allocationList, responseBody);
            }

            return response;
        }
    }
}
