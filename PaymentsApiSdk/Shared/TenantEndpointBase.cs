using System;
using System.Net.Http;

namespace PingPayments.PaymentsApi.Shared
{
    public abstract class TenantEndpointBase<Request, Response> : EndpointBase<Request, Response>
    {
        protected TenantEndpointBase(HttpClient httpClient, Guid tenantId) : base(httpClient)
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("tenant_id"))
            {
                _httpClient.DefaultRequestHeaders.Add("tenant_id", tenantId.ToString());
            }            
        }
    }
}
