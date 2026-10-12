using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request;
using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response;
using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1
{
    public class ActivateQuickpayVippsOperation : OperationBase<(Guid merchantId, ActivateQuickpayVippsRequest request), ActivateQuickpayResponse>
    {
        public ActivateQuickpayVippsOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ActivateQuickpayResponse> ExecuteRequest((Guid merchantId, ActivateQuickpayVippsRequest request) request)
        {
            using var content = ToForm(request.request);
            return await BaseExecute
            (
                POST,
                $"api/v1/merchants/{request.merchantId}/payment_provider_methods/activations",
                request,
                content
            );
        }

        protected override async Task<ActivateQuickpayResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid merchantId, ActivateQuickpayVippsRequest request) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => ActivateQuickpayResponse.Successful(hrm.StatusCode, await Deserialize<ActivateQuickpayResponseBody>(responseBody), responseBody),
                _ => ActivateQuickpayResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }

        private static MultipartFormDataContent ToForm(ActivateQuickpayVippsRequest request)
        {
            var parameters = request.ProviderMethodParameters;
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(request.Provider.ToString()), JsonName<ActivateQuickpayVippsRequest>(nameof(ActivateQuickpayVippsRequest.Provider)));
            form.Add(new StringContent(request.Method.ToString()), JsonName<ActivateQuickpayVippsRequest>(nameof(ActivateQuickpayVippsRequest.Method)));
            if (request.StatusCallbackUrl != null)
                form.Add(new StringContent(request.StatusCallbackUrl.ToString()), JsonName<ActivateQuickpayVippsRequest>(nameof(ActivateQuickpayVippsRequest.StatusCallbackUrl)));

            form.Add(new StringContent(parameters.Email), ParameterField(nameof(ActivateQuickpayVippsParameters.Email)));
            AddOptional(form, ParameterField(nameof(ActivateQuickpayVippsParameters.AddressLine)), parameters.AddressLine);
            AddOptional(form, ParameterField(nameof(ActivateQuickpayVippsParameters.City)), parameters.City);
            AddOptional(form, ParameterField(nameof(ActivateQuickpayVippsParameters.PostalCode)), parameters.PostalCode);

            var logo = new ByteArrayContent(parameters.Logo);
            logo.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            form.Add(logo, ParameterField(nameof(ActivateQuickpayVippsParameters.Logo)), parameters.LogoFileName);
            return form;
        }

        private static string ParameterField(string propertyName) =>
            $"{JsonName<ActivateQuickpayVippsRequest>(nameof(ActivateQuickpayVippsRequest.ProviderMethodParameters))}[{JsonName<ActivateQuickpayVippsParameters>(propertyName)}]";

        private static string JsonName<T>(string propertyName)
        {
            var name = typeof(T).GetProperty(propertyName)?.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name;
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException($"Missing JsonPropertyName on {typeof(T).Name}.{propertyName}.");
            return name;
        }

        private static void AddOptional(MultipartFormDataContent form, string name, string? value)
        {
            if (value != null)
                form.Add(new StringContent(value), name);
        }
    }
}
