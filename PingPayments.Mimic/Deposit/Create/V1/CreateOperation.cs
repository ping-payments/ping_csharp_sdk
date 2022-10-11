using PingPayments.Shared;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.Mimic.Deposit.Create.V1
{
    public class CreateOperation : OperationBase<CreateDepositRequest, EmptyResponse>
    {
        public CreateOperation(HttpClient httpClient) : base(httpClient) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new JsonStringEnumConverter(),
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<EmptyResponse> ExecuteRequest(CreateDepositRequest createDepositRequest) =>
            await BaseExecute
            (
                POST,
                "api/deposit_payment",
                createDepositRequest,
                await ToJson(createDepositRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, CreateDepositRequest _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}
