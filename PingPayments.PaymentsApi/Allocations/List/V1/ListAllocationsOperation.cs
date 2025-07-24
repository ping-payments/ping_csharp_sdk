using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Allocations.List.V1
{
    public class ListAllocationsOperation : OperationBase<(Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId)?, ListAllocationResponse>
    {
        public ListAllocationsOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<ListAllocationResponse> ExecuteRequest((Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId)? filter) =>
            BaseExecute
            (
                GET,
                filter.HasValue
                    ? ("api/v1/allocations?" +
                        (filter.Value.paymentId.HasValue ? $"payment_id={filter.Value.paymentId}&" : string.Empty) +
                        (filter.Value.paymentOrderId.HasValue ? $"payment_order_id={filter.Value.paymentOrderId}&" : string.Empty) +
                        (filter.Value.disbursementId.HasValue ? $"disbursement_id={filter.Value.disbursementId}&" : string.Empty) +
                        (filter.Value.payoutId.HasValue ? $"payout_id={filter.Value.payoutId}&" : string.Empty) +
                        (filter.Value.merchantId.HasValue ? $"merchant_id={filter.Value.merchantId}" : string.Empty))
                    : "api/v1/allocations",
                filter
            );

        public async Task<ListAllocationResponse> ExecuteRequest(PaginationLinkHref href, (Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId)? request) =>
            await BaseExecute
            (
                GET,
                href.Href,
                request
            );

        protected override async Task<ListAllocationResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId)? request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => ListAllocationResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<ListAllocationResponse> GetSuccessful()
            {
                var genericResponseObject = await Deserialize<GenericTransfer<Allocation>>(responseBody);
                Allocation[] objectArray = genericResponseObject?.Data ?? Array.Empty<Allocation>();
                if (genericResponseObject?.PaginationLinks.Next?.Href != null)
                {
                    var recursiveResponse = await ExecuteRequest(genericResponseObject!.PaginationLinks.Next!, request);
                    if (recursiveResponse.IsSuccessful)
                    {
                        int oldLen = objectArray.Length;
                        Array.Resize<Allocation>(ref objectArray, oldLen + (recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0));
                        Array.Copy(recursiveResponse.Body?.SuccessfulResponseBody ?? Array.Empty<Allocation>(), 0, objectArray, oldLen, recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0);
                    }
                    else
                    {
                        return ListAllocationResponse.Failure(recursiveResponse.StatusCode, recursiveResponse.Body?.ErrorResponseBody, responseBody);
                    }
                }
                return ListAllocationResponse.Successful(hrm.StatusCode, objectArray, responseBody);
            }
        }
    }
}
