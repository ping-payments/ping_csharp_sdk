using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.PaymentsApi.Allocations.Shared;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Allocations.List.V1
{
    public class ListAllocationsDataOperation : OperationBase<(Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId), ListAllocationDataResponse>
    {
        public ListAllocationsDataOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ListAllocationDataResponse> ExecuteRequest((Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) request) =>
            await GetPaginatedListAsync<Allocation, ListAllocationDataResponse>(("api/v1/allocations?" +
                (request.paymentId.HasValue ? $"payment_id={request.paymentId}&" : string.Empty) +
                (request.paymentOrderId.HasValue ? $"payment_order_id={request.paymentOrderId}&" : string.Empty) +
                (request.disbursementId.HasValue ? $"disbursement_id={request.disbursementId}&" : string.Empty) +
                (request.payoutId.HasValue ? $"payout_id={request.payoutId}&" : string.Empty) +
                (request.merchantId.HasValue ? $"merchant_id={request.merchantId}" : string.Empty)),
                (isSuccess, statusCode, data, rawBody, error) =>
                    isSuccess
                        ? ListAllocationDataResponse.Successful(statusCode, data.ToArray(), rawBody)
                        : ListAllocationDataResponse.Failure(statusCode, error, rawBody)
                );

        protected override Task<ListAllocationDataResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) _)
        {
            throw new NotImplementedException("This method should not be called directly. Use ExecuteRequest instead.");
        }

    }

}
