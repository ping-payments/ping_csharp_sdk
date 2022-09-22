using PingPayments.KYC.Merchant.V1.Get.Response;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.KYC.Merchant.V1.Get
{
    public class GetMerchantKycOperation : OperationBase<GetMerchantKycRequest, GetMerchantKycResponse>
    {
        public GetMerchantKycOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<GetMerchantKycResponse> ExecuteRequest(GetMerchantKycRequest request)
            => BaseExecute
            (
                GET,
                $"api/tenant/{request.TenantId}/merchants?" +
                //$"page_size={request.PageSize}&" +
                //$"page={request.Page}&" +
                //$"type={request.Type}&" +
                $"merchant_id={request.MerchantId}",
                request
            );

        protected override async Task<GetMerchantKycResponse> ParseHttpResponse(HttpResponseMessage hrm, GetMerchantKycRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccesful(),
                _ => GetMerchantKycResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<GetMerchantKycResponse> GetSuccesful()
            {
                var paymentOrders = await Deserialize<GetMerchantKycResponseBody[]?>(responseBody);
                var paymentOrderList = paymentOrders != null ? new MerchantKycVerificationList(paymentOrders) : null;
                var response = GetMerchantKycResponse.Succesful(hrm.StatusCode, paymentOrderList, responseBody);
                return response;
            }
        }
    }
}
