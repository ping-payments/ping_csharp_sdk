﻿using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PingTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.Ping.V1.Ping();
            AssertHttpOK(response);
            Assert.Equal("pong", response.Body.SuccessfulResponseBody.Text);
        }
    }
}
