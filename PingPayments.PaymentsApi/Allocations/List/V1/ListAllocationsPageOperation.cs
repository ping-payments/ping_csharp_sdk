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
    public class ListAllocationsPageOperation : OperationBase<(PaginationLinkHref? href, Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId, int? limit)?, ListAllocationPageResponse>
    {
        public ListAllocationsPageOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<ListAllocationPageResponse> ExecuteRequest((PaginationLinkHref? href, Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId, int? limit)? request) =>
            BaseExecute
            (
                GET,
                request.HasValue && !string.IsNullOrEmpty(request.Value.href?.Href)
                    ? request.Value.href!.Href
                    : request.HasValue
                        ? ("api/v1/allocations?" +
                            (request.Value.paymentId.HasValue ? $"payment_id={request.Value.paymentId}&" : string.Empty) +
                            (request.Value.paymentOrderId.HasValue ? $"payment_order_id={request.Value.paymentOrderId}&" : string.Empty) +
                            (request.Value.disbursementId.HasValue ? $"disbursement_id={request.Value.disbursementId}&" : string.Empty) +
                            (request.Value.payoutId.HasValue ? $"payout_id={request.Value.payoutId}&" : string.Empty) +
                            (request.Value.merchantId.HasValue ? $"merchant_id={request.Value.merchantId}&" : string.Empty) +
                            (request.Value.limit.HasValue ? $"limit={request.Value.limit.Value}" : string.Empty))
                        : "api/v1/allocations",
                request
            );

        protected override async Task<ListAllocationPageResponse> ParseHttpResponse(HttpResponseMessage hrm, (PaginationLinkHref? href, Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId, int? limit)? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => ListAllocationPageResponse.Successful(hrm.StatusCode, await Deserialize<GenericTransfer<Allocation>>(responseBody), responseBody),        // await GetSuccessful(),
                _ => ListAllocationPageResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
