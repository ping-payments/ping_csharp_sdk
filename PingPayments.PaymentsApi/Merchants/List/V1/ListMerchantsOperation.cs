using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public class ListMerchantsOperation : OperationBase<EmptyRequest?, MerchantsResponse>
    {
        public ListMerchantsOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<MerchantsResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) => 
            await BaseExecute(GET, $"api/v1/merchants", emptyRequest);

        protected override async Task<MerchantsResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => MerchantsResponse.Succesful(hrm.StatusCode, new MerchantList(await Deserialize<Merchant[]>(responseBody)), responseBody),
                _ => MerchantsResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}