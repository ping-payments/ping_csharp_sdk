using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;

namespace PingPayments.KYC.Merchant.V1.List
{
    public class ListOperation : OperationBase<(Guid tenantId, ListOperationRequest listOperationRequest), ListOperationResponse>
    {
        public ListOperation(HttpClient httpClient) : base(httpClient) { }

        public override Task<ListOperationResponse> ExecuteRequest((Guid tenantId, ListOperationRequest? listOperationRequest) request)
            => BaseExecute
            (
                GET,
                $"api/tenant/{request.tenantId}/merchants?" +
                $"page_size={request.listOperationRequest.PageSize}&" +
                $"page={request.listOperationRequest.Page}&" +
                $"type={request.listOperationRequest.Type}&" +
                $"merchant_id={request.listOperationRequest.MerchantId}",
                request
            );

        protected override async Task<ListOperationResponse> ParseHttpResponse(HttpResponseMessage response, (Guid tenantId, ListOperationRequest listOperationRequest) request)
        {
            throw new NotImplementedException();
        }
    }
}
