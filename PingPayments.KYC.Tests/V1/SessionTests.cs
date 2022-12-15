using PingPayments.KYC.Session.V1.Initiate;
using PingPayments.KYC.Shared;

namespace PingPayments.KYC.Tests.V1
{
    public class SessionTests : KYCApiTestClient
    {
        [Fact]
        public async Task Initiate_Created_returns_201()
        {
            var redirects = new Redirects
            {
                CancelUrl = new Uri("https://www.google.com/search?q=cancel"),
                SuccessUrl = new Uri("https://www.google.com/search?q=success"),
                TimeoutUrl = new Uri("https://www.google.com/search?q=timeout")

            };
            var request = new InitiateSessionRequest("Name@mail.com", "0706542314", "199409082333", redirects);

            var response = await _api.Session.V1.Initiate(request);
            AssertHttpCreated(response);
        }

        [Fact]
        public async Task Initiate_bad_request_returns_400()
        {
            var request = new InitiateSessionRequest("Name@mail.com", "0706542314", null);
            var response = await _api.Session.V1.Initiate(request);
            AssertBadRequest(response);
        }

    }
}
