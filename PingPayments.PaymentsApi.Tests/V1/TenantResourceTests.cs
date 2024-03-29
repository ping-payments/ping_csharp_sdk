﻿using PingPayments.PaymentsApi.Tenants.Update.V1;
using PingPayments.Tests;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tests.V1
{

    public class TenantResourceTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Get_Correctly_returns_200()
        {
            var response = await _api.Tenants.V1.Get();
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Update_Correctly_returns_204()
        {
            var request = new UpdateTenantRequest
                (
                CreditAccountTopUpCallbackUrl: TestData.FakeCallback,
                MerchantStatusCallbackUrl: TestData.FakeCallback
                );

            var response = await _api.Tenants.V1.Update(request);
            AssertHttpNoContent(response);
        }
    }
}
