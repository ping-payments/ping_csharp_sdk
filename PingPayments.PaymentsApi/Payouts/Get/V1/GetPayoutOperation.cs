using PingPayments.PaymentsApi.Payouts.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payouts.Get.V1
{
    public class GetPayoutOperation : OperationBase<Guid, PayoutGetResponse>
    {
        public GetPayoutOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PayoutGetResponse> ExecuteRequest(Guid PayoutId) =>
            await BaseExecute(GET, $"api/v1/payouts/{PayoutId}", PayoutId);

        protected override async Task<PayoutGetResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PayoutGetResponse.Successful(hrm.StatusCode, await Deserialize<PayoutResponseBody>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }
        protected async Task<PayoutGetResponse> ToError(HttpResponseMessage hrm) =>
            PayoutGetResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}
