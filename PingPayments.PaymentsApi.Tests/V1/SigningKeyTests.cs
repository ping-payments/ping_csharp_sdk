﻿using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class SigningKeyTests : BaseResourceTests
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.SigningKey.V1.Get();
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Generate_returns_200()
        {
            var response = await _api.SigningKey.V1.Generate();
            AssertHttpOK(response);
        }
    }
}
