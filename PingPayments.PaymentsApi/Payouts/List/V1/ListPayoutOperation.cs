using PingPayments.PaymentsApi.Payouts.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payouts.List.V1
{
    public class ListPayoutOperation : OperationBase<(DateTimeOffset from, DateTimeOffset to)?, PayoutListResponse>
    {
        public ListPayoutOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PayoutListResponse> ExecuteRequest((DateTimeOffset from, DateTimeOffset to)? request) =>
            await BaseExecute
            (
                GET,
                request.HasValue ?
                    ($"api/v1/payouts?" +
                        $"from={WebUtility.UrlEncode(request.Value.from.ToString("o"))}&" +
                        $"to={WebUtility.UrlEncode(request.Value.to.ToString("o"))}")
                :
                    $"api/v1/payouts",
                request
             );

        protected override async Task<PayoutListResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset from, DateTimeOffset to)? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccesful(),
                _ => PayoutListResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<PayoutListResponse> GetSuccesful()
            {
                var payouts = await Deserialize<PayoutResponseBody[]?>(responseBody);
                var payoutList = payouts != null ? new PayoutListResponseBody(payouts) : null;
                var response = PayoutListResponse.Succesful(hrm.StatusCode, payoutList, responseBody);
                return response;
            }
        }
    }
}
