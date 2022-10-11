using PingPayments.PaymentsApi.Disbursements.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Disbursements.List.V1
{
    public class ListDisbursementsOperation : OperationBase<(DateTimeOffset from, DateTimeOffset to)?, ListDisbursementResponse>
    {
        public ListDisbursementsOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<ListDisbursementResponse> ExecuteRequest((DateTimeOffset from, DateTimeOffset to)? request) =>
            BaseExecute
            (
                GET,
                request.HasValue ?
                    ("api/v1/disbursements?" +
                        $"from={WebUtility.UrlEncode(request.Value.from.ToString("o"))}&" +
                        $"to={WebUtility.UrlEncode(request.Value.to.ToString("o"))}")
                :
                    "api/v1/disbursements",
                request
            );

        protected override async Task<ListDisbursementResponse> ParseHttpResponse(HttpResponseMessage hrm, (DateTimeOffset from, DateTimeOffset to)? request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => ListDisbursementResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<ListDisbursementResponse> GetSuccessful()
            {
                var disbursements = await Deserialize<Disbursement[]?>(responseBody);
                var disbursementList = disbursements != null ? new DisbursementList(disbursements) : null;
                var response = ListDisbursementResponse.Successful(hrm.StatusCode, disbursementList, responseBody);
                return response;
            }
        }
    }
}
