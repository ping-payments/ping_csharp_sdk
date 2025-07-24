using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public class ListMerchantsOperation : OperationBase<EmptyRequest?, MerchantsResponse>
    {
        public ListMerchantsOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<MerchantsResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) =>
            await BaseExecute(GET, $"api/v1/merchants", emptyRequest);

        private async Task<MerchantsResponse> ExecuteRequest(PaginationLinkHref href, EmptyRequest? emptyRequest = null) =>
            await BaseExecute(GET, href.Href, emptyRequest);

        protected override async Task<MerchantsResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? emptyRequest)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => await GetSuccessful(),
                _ => MerchantsResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;

            async Task<MerchantsResponse> GetSuccessful()
            {
                var genericResponseObject = await Deserialize<GenericTransfer<Merchant>>(responseBody);
                Merchant[] objectArray = genericResponseObject?.Data ?? Array.Empty<Merchant>();
                if (genericResponseObject?.PaginationLinks.Next?.Href != null)
                {
                    var recursiveResponse = await ExecuteRequest(genericResponseObject!.PaginationLinks.Next!, emptyRequest);
                    if (recursiveResponse.IsSuccessful)
                    {
                        int oldLen = objectArray.Length;
                        Array.Resize<Merchant>(ref objectArray, oldLen + (recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0));
                        Array.Copy(recursiveResponse.Body?.SuccessfulResponseBody ?? Array.Empty<Merchant>(), 0, objectArray, oldLen, recursiveResponse.Body?.SuccessfulResponseBody?.Length ?? 0);
                    }
                    else
                    {
                        return MerchantsResponse.Failure(recursiveResponse.StatusCode, recursiveResponse.Body?.ErrorResponseBody, responseBody);
                    }
                }
                return MerchantsResponse.Successful(hrm.StatusCode, objectArray, responseBody);
            }
        }
    }
}