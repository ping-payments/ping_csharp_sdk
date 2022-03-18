using System;
using System.Net.Http;

namespace PaymentsApiSdk.Shared
{
    public abstract class TenantEndpointBase<Request, Response> : EndpointBase<Request, Response>
    {
        protected TenantEndpointBase(HttpClient httpClient, Guid tenantId) : base(httpClient)
        {
            _httpClient.DefaultRequestHeaders.Add("tenant_id", tenantId.ToString());
        }
    }
}
