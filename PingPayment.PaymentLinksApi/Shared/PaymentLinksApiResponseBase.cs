using System.Net;

namespace PingPayments.PaymentLinksApi.Shared
{
    public abstract record PaymentLinksApiResponseBase<T>(HttpStatusCode StatusCode, bool IsSuccessful, PaymentLinksResponseBody<T>? Body, string RawBody) where T : class
    {
        public bool IsFailure => !IsSuccessful;

        public bool ParsingError =>
            IsSuccessful &&
            !string.IsNullOrWhiteSpace(RawBody) &&
            Body?.SuccessfulResponseBody == null;

        public static implicit operator PaymentLinksErrorResponseBody?(PaymentLinksApiResponseBase<T> apiResponseBase) =>
            apiResponseBase.IsFailure &&
            apiResponseBase.Body?.ErrorResponseBody != null ?
                apiResponseBase.Body.ErrorResponseBody :
                null;

        public void Match(Action<T> OnSuccess, Action<PaymentLinksErrorResponseBody> OnFailure)
        {
            if (IsSuccessful)
            {
                OnSuccess.Invoke(Body?.SuccessfulResponseBody);
            }
            else
            {
                OnFailure.Invoke(Body?.ErrorResponseBody);
            }
        }

        public async Task MatchAsync(Func<T, Task> OnSuccess, Func<PaymentLinksErrorResponseBody, Task> OnFailure)
        {
            if (IsSuccessful)
            {
                await OnSuccess(Body?.SuccessfulResponseBody);
            }
            else
            {
                await OnFailure(Body?.ErrorResponseBody);
            }
        }
    }
}
