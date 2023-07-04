using PingPayments.Shared;
using System.Net;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests
{
    public class MatchTests
    {
        public record StringResponseBody(string Text) : EmptySuccessfulResponseBody;
        public record FakeResponse : ApiResponseBase<StringResponseBody>
        {
            public FakeResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<StringResponseBody>? Body, string RawBody) :
                base(StatusCode, IsSuccessful, Body, RawBody)
            { }
        }

        [Fact]
        public void Can_match_on_successful()
        {
            var successfulResponse = new FakeResponse(HttpStatusCode.OK, true, new StringResponseBody("Foobar"), "Foobar");
            successfulResponse.Match
            (
                OnSuccess: (StringResponseBody s) => { Assert.Equal("Foobar", s.Text); },
                OnFailure: (ErrorResponseBody e) => { throw new System.Exception("test should not go here!"); }
            );
        }

        [Fact]
        public void Can_match_on_failure()
        {
            var failedResponse = new FakeResponse(HttpStatusCode.OK, false, new ErrorResponseBody(), "{}");
            failedResponse.Match
            (
                OnSuccess: (StringResponseBody s) => { throw new System.Exception("test should not go here!"); },
                OnFailure: (ErrorResponseBody e) => { Assert.NotNull(e); }
            );
        }

        [Fact]
        public async Task Can_matchasync_on_successful()
        {
            var successfulResponse = new FakeResponse(HttpStatusCode.OK, true, new StringResponseBody("Foobar"), "Foobar");
            await successfulResponse.MatchAsync
            (
                OnSuccess: async (StringResponseBody s) => { await Task.Run(() => Assert.Equal("Foobar", s.Text)); },
                OnFailure: async (ErrorResponseBody e) => { await Task.Run(() => throw new System.Exception("test should not go here!")); }
            );
        }

        [Fact]
        public async Task Can_matchasync_on_failure()
        {
            var failedResponse = new FakeResponse(HttpStatusCode.OK, false, new ErrorResponseBody(), "{}");
            await failedResponse.MatchAsync
            (
                OnSuccess: async (StringResponseBody s) => { await Task.Run(() => throw new System.Exception("test should not go here!")); },
                OnFailure: async (ErrorResponseBody e) => { await Task.Run(() => Assert.NotNull(e)); }
            );
        }
    }
}
