using PingPayments.PaymentsApi.Allocations.List.V1;
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
    public class ListMerchantsDataOperation : OperationBase<EmptyRequest?, MerchantsDataResponse>
    {
        public ListMerchantsDataOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<MerchantsDataResponse> ExecuteRequest(EmptyRequest? emptyRequest = null) =>
            await GetPaginatedListAsync<Merchant, MerchantsDataResponse>("api/v1/merchants",
                (isSuccess, statusCode, data, rawBody, error) =>
                    isSuccess
                        ? MerchantsDataResponse.Successful(statusCode, data.ToArray(), rawBody)
                        : MerchantsDataResponse.Failure(statusCode, error, rawBody)
            );

        protected override Task<MerchantsDataResponse> ParseHttpResponse(HttpResponseMessage hrm, EmptyRequest? emptyRequest)
        {
            throw new NotImplementedException("This method should not be called directly. Use ExecuteRequest instead.");
        }

    }
}