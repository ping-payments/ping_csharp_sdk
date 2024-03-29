﻿using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1
{
    public class CreatePaymentLinkOperation : OperationBase<CreatePaymentLinkRequest, CreatePaymentLinkResponse>
    {
        public CreatePaymentLinkOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public override async Task<CreatePaymentLinkResponse> ExecuteRequest(CreatePaymentLinkRequest request) =>
        await BaseExecute
            (
                POST,
                $"api/v1/payment_links",
                request,
                await ToJson(request)
            );

        protected override async Task<CreatePaymentLinkResponse> ParseHttpResponse(HttpResponseMessage hrm, CreatePaymentLinkRequest request)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => CreatePaymentLinkResponse.Successful(hrm.StatusCode, await Deserialize<CreatePaymentLinkResponseBody>(responseBody), responseBody),
                _ => CreatePaymentLinkResponse.Failure(hrm.StatusCode, await Deserialize<PaymentLinksErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
