using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Create.V1
{
    public class CreateLiquidityAccountOperation : OperationBase<CreateLiquidityAccountRequest, CreateLiquidityAccountResponse>
    {
        public CreateLiquidityAccountOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<CreateLiquidityAccountResponse> ExecuteRequest(CreateLiquidityAccountRequest createLiquidityAccountRequest) =>
            await BaseExecute
            (
                POST,
                $"api/v1/liquidity_accounts",
                createLiquidityAccountRequest,
                await ToJson(createLiquidityAccountRequest)
            );

        protected override async Task<CreateLiquidityAccountResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateLiquidityAccountRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreateLiquidityAccountResponse.Successful(hrm.StatusCode, await Deserialize<CreateLiquidityAccountResponseBody>(responseBody), responseBody),
                _ => CreateLiquidityAccountResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}