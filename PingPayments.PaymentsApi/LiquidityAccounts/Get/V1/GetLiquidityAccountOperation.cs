using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Get.V1
{
    public class GetLiquidityAccountOperation : OperationBase<Guid, GetLiquidityAccountResponse>
    {
        public GetLiquidityAccountOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<GetLiquidityAccountResponse> ExecuteRequest(Guid merchantId) =>
            await BaseExecute(GET, $"api/v1/liquidity_accounts/{merchantId}", merchantId);

        protected override async Task<GetLiquidityAccountResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => GetLiquidityAccountResponse.Successful(hrm.StatusCode, await Deserialize<GetLiquidityAccountResponseBody>(responseBody), responseBody),
                _ => GetLiquidityAccountResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}