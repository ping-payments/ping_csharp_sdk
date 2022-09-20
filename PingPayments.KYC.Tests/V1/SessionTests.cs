using PingPayments.KYC.Session.V1.Initiate;
using PingPayments.KYC.Shared;

namespace PingPayments.KYC.Tests.V1
{
    public class SessionTests : BaseResourceTests
    {
        [Fact]
        public async Task Iniaiate_returns_200()
        {
            var request = new InitiateSessionRequest
            {
                Email = "Name@mail.com",
                Phone = "0706542314",
                PsuId = "199409082333",
                Redirects = new Redirects
                {
                    CancelUrl = new Uri("https://www.google.com/search?q=cancel"),
                    SuccessUrl = new Uri("https://www.google.com/search?q=success"),
                    TimeoutUrl = new Uri("https://www.google.com/search?q=timeout")

                },
                Styles = new Styles
                {
                    BackgroundColor = "#47e331",
                    FormBackgroundColor = "#44aacc",
                    Primary = "#ffe7ec"
                },
                TenantId = "a2a4f648-a50b-42fb-bda8-00c6e2f295ea"

            };
            var response = await _api.Session.V1.Initiate(request);
            AssertHttpOK(response);
        }
    }
}
