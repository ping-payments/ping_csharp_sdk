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
                 $"api/tenant/{request.TenantId}/merchants?" +
                    (request.MerchantId.HasValue ? $"merchant_id={request.MerchantId}"
                :
                    $"page_size={request.PageSize}&" +
                    $"page={request.Page}&" +
                    $"type={request.Type}"),
                request
            );

        protected override async Task<GetKycResponse> ParseHttpResponse(HttpResponseMessage hrm, GetKycRequest _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => GetKycResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<GetKycResponse> GetSuccessful()
            {
                var kycVerifications = await Deserialize<KycResponseBody[]?>(responseBody);
                var kycVerificationList = kycVerifications != null ? new KycVerificationList(kycVerifications) : null;
                var response = GetKycResponse.Successful(hrm.StatusCode, kycVerificationList, responseBody);
                return response;
            }
        }
    }
}
