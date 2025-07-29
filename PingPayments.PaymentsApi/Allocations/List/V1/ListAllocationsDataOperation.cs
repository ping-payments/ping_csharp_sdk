using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
        ExecuteRequestGeneric(("api/v1/allocations?" +
            (filter.paymentId.HasValue ? $"payment_id={filter.paymentId}&" : string.Empty) +
            (filter.paymentOrderId.HasValue ? $"payment_order_id={filter.paymentOrderId}&" : string.Empty) +
            (filter.disbursementId.HasValue ? $"disbursement_id={filter.disbursementId}&" : string.Empty) +
            (filter.payoutId.HasValue ? $"payout_id={filter.payoutId}&" : string.Empty) +
            (filter.merchantId.HasValue ? $"merchant_id={filter.merchantId}" : string.Empty)));

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

        public async Task<ListAllocationDataResponse> ExecuteRequestGeneric(string nextUrl)
        {
            var genericList = new GenericList<Allocation>(_httpClient);
            var response = await genericList.GetTListAsync(
                nextUrl,
                (isSuccess, statusCode, data, rawBody, error) =>
                    isSuccess
                        ? ListAllocationDataResponse.Successful(statusCode, data.ToArray(), rawBody)
                        : ListAllocationDataResponse.Failure(statusCode, error, rawBody)
            );
            return response;
        } 

        public async Task<ListAllocationDataResponse> ExecuteRequestIterative(string? nextUrl)
        {
            var allAllocations = new List<Allocation>();

            HttpStatusCode lastStatusCode = HttpStatusCode.OK;
            string lastRawBody = string.Empty;

            while (!string.IsNullOrEmpty(nextUrl))
            {
                using var response = await _httpClient.GetAsync(nextUrl);
                lastStatusCode = response.StatusCode;
                lastRawBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var error = await Deserialize<ErrorResponseBody>(lastRawBody);
                    return ListAllocationDataResponse.Failure(response.StatusCode, error, lastRawBody);
                }

                var genericResponseObject = await Deserialize<GenericTransfer<Allocation>>(lastRawBody);
                if (genericResponseObject?.Data != null)
                    allAllocations.AddRange(genericResponseObject.Data);

                nextUrl = genericResponseObject?.PaginationLinks.Next?.Href;
            }

            return ListAllocationDataResponse.Successful(lastStatusCode, allAllocations.ToArray(), lastRawBody);
        }

    }

}
