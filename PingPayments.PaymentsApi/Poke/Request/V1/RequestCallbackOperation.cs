﻿using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Poke.Request.V1
{
    public class RequestCallbackOperation : OperationBase<Uri, EmptyResponse>
    {
        public RequestCallbackOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(Uri callbackUrl) =>
            await BaseExecute
            (
                POST,
                "api/v1/poke",
                callbackUrl,
                await ToJson((new { callback_url = callbackUrl }))
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Uri _) =>
            hrm.StatusCode switch
            {
                OK => EmptyResponse.Successful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}
