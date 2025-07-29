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
    public class ListAllocationsDataOperation : OperationBase<(Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId), ListAllocationDataResponse>
    {
        public ListAllocationsDataOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<ListAllocationDataResponse> ExecuteRequest((Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) filter) =>
            BaseExecute
            (
                GET,
                ("api/v1/allocations?" +
                    (filter.paymentId.HasValue ? $"payment_id={filter.paymentId}&" : string.Empty) +
                    (filter.paymentOrderId.HasValue ? $"payment_order_id={filter.paymentOrderId}&" : string.Empty) +
                    (filter.disbursementId.HasValue ? $"disbursement_id={filter.disbursementId}&" : string.Empty) +
                    (filter.payoutId.HasValue ? $"payout_id={filter.payoutId}&" : string.Empty) +
                    (filter.merchantId.HasValue ? $"merchant_id={filter.merchantId}" : string.Empty)),
                filter
            );

        public async Task<ListAllocationDataResponse> ExecuteRequest(PaginationLinkHref href, (Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) request) =>
            await BaseExecute
            (
                GET,
                href.Href,
                request
            );

        protected override async Task<ListAllocationDataResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => ListAllocationDataResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<ListAllocationDataResponse> GetSuccessful()
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
                        return ListAllocationDataResponse.Failure(recursiveResponse.StatusCode, recursiveResponse.Body?.ErrorResponseBody, responseBody);
                    }
                }
                return ListAllocationDataResponse.Successful(hrm.StatusCode, objectArray, responseBody);
            }
        }
    }
}
