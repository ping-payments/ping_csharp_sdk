using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payout.List.V1
{

    public class ListOperation : OperationBase<(DateTimeOffset from, DateTimeOffset to)?, PayoutListResponse>
    {
        public ListOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override async Task<PayoutListResponse> ExecuteRequest((DateTimeOffset from, DateTimeOffset to)? request)
        {
            var hasIntervallFilter = request != null;
            if (hasIntervallFilter)
            {
                DateTimeOffset from = request.Value.from;
                var fromUrlFriendly = WebUtility.UrlEncode(from.ToString("o"));

                DateTimeOffset to = request.Value.to;
                var toUrlFriendly = WebUtility.UrlEncode(to.ToString("o"));

                var url = $"api/v1/payment_orders?from={fromUrlFriendly}&to={toUrlFriendly}";

                var response = await BaseExecute(RequestTypeEnum.GET, url, request, null);
                return response;
            }
            else
            {
                var response = await BaseExecute(RequestTypeEnum.GET, "api/v1/payouts", null, null);
                return response;
            }
        }

        protected override async Task<PayoutListResponse> ParseHttpResponse(HttpResponseMessage response, (DateTimeOffset from, DateTimeOffset to)? _)
        {
            var responseBody = await response.Content.ReadAsStringAsyncMemoized();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var payouts = await Deserialize<Payout[]?>(responseBody);
                var payoutListResponseBody = new PayoutListResponseBody(payouts ?? Array.Empty<Payout>());
                var payoutList = new PayoutListResponse(HttpStatusCode.OK, true, payoutListResponseBody, responseBody);
                return payoutList;
            }
            else
            {
                var errorBody = await Deserialize<ErrorResponseBody>(responseBody);
                var payoutList = new PayoutListResponse(response.StatusCode, false, errorBody, responseBody);
                return payoutList;
            }
        }
    }
}
