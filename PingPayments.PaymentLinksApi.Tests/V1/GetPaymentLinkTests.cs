using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.Tests.V1
{
  
    public class GetPaymentLinkTests : BaseResourceTests
    {
        [Fact]
        public async Task GetPaymentLink_returns_200()
        {
            var response = await _api.PaymentLinks.V1.Get(TestData.PaymentLinkId);
            AssertHttpOK(response);
        }
    }
}

