using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.SigningKeys.Get.V1
{
    public class GetKeyOperation : OperationBase<EmptyRequest, GetKeyRespons>
    {
        public GetKeyOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<GetKeyRespons> ExecuteRequest(EmptyRequest request) =>
            await BaseExecute(GET, "api/v1/signing_key", request);

        protected override async Task<GetKeyRespons> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GetKeyRespons.Succesful(hrm.StatusCode, await Deserialize<GetKeyResponseBody>(responseBody), responseBody),
                _ => GetKeyRespons.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
