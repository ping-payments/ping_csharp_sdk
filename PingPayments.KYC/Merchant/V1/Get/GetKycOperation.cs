using PingPayments.KYC.Merchant.V1.Get.Response;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Merchant.V1.Get
{
    public class GetKycOperation : OperationBase<GetKycRequest, GetKycResponse>
    {
        public GetKycOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<GetKycResponse> ExecuteRequest(GetKycRequest request)
            => BaseExecute
            (
                GET,
                request.MerchantId.HasValue ? $"api/tenant/{request.TenantId}/merchants?merchant_id={request.MerchantId}"
                :
                $"api/tenant/{request.TenantId}/merchants?" +
                $"page_size={request.PageSize}&" +
                $"page={request.Page}&" +
                $"type={request.Type}&",
                request
            );

        protected override async Task<GetKycResponse> ParseHttpResponse(HttpResponseMessage hrm, GetKycRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccesful(),
                _ => GetKycResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<GetKycResponse> GetSuccesful()
            {
                var kycs = await Deserialize<KycResponseBody[]?>(responseBody);
                var kycList = kycs != null ? new KycList(kycs) : null;
                var response = GetKycResponse.Succesful(hrm.StatusCode, kycList, responseBody);
                return response;
            }
        }
    }
}
