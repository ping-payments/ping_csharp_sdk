using PingPayments.PaymentsApi.Disbursements.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Disbursements.Get.V1
{
    public class GetDisbursementOperation : OperationBase<Guid, GetDisbursementResponse>
    {
        public GetDisbursementOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<GetDisbursementResponse> ExecuteRequest(Guid disbursementId) =>
            BaseExecute(GET, $"api/v1/disbursements/{disbursementId}", disbursementId);

        protected override async Task<GetDisbursementResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GetDisbursementResponse.Successful(hrm.StatusCode, await Deserialize<Disbursement>(responseBody), responseBody),
                _ => GetDisbursementResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()), await hrm.Content.ReadAsStringAsyncMemoized())
            };
            return response;
        }
    }
}
