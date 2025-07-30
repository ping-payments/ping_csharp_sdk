using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public class ListMerchantsPageOperation : OperationBase<(PaginationLinkHref? href, int? limit)?, MerchantsPageResponse>
    {
        public ListMerchantsPageOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<MerchantsPageResponse> ExecuteRequest((PaginationLinkHref? href, int? limit)? request = null) =>
            await BaseExecute
            (
                GET,
                request.HasValue && !string.IsNullOrEmpty(request.Value.href?.Href)
                    ? request.Value.href!.Href
                    : request!.Value.limit.HasValue
                        ? $"api/v1/merchants?limit={request!.Value.limit.Value}"
                        : "api/v1/merchants",
                request
            );

        protected override async Task<MerchantsPageResponse> ParseHttpResponse(HttpResponseMessage hrm, (PaginationLinkHref? href, int? limit)? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => MerchantsPageResponse.Successful(hrm.StatusCode, await Deserialize<GenericTransfer<Merchant>>(responseBody), responseBody),
                _ => MerchantsPageResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }

    }
}