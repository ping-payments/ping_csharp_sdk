using System.Net;

namespace PingPayments.PaymentLinksApi.Shared
{
    public abstract record ApiResponseBase<T>(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<T>? Body, string RawBody) where T : EmptySuccesfulResponseBody
    {
        public bool IsFailure => !IsSuccessful;

        public bool ParsingError => 
            IsSuccessful && 
            !string.IsNullOrWhiteSpace(RawBody) &&
            Body?.SuccesfulResponseBody == null;

        public static implicit operator ErrorResponseBody?(ApiResponseBase<T> apiResponseBase) =>
            apiResponseBase.IsFailure &&
            apiResponseBase.Body?.ErrorResponseBody != null ?
                apiResponseBase.Body.ErrorResponseBody :
                null;

        public void Match(Action<T> OnSuccess, Action<ErrorResponseBody> OnFailure)
        {
            if(IsSuccessful)  
            {
                OnSuccess.Invoke(Body?.SuccesfulResponseBody);
            } 
            else 
            {
                OnFailure.Invoke(Body?.ErrorResponseBody);
            }
        }

        public async Task MatchAsync(Func<T, Task> OnSuccess, Func<ErrorResponseBody, Task> OnFailure)
        {
            if (IsSuccessful)
            {
                await OnSuccess(Body?.SuccesfulResponseBody);
            }
            else
            {
                await OnFailure(Body?.ErrorResponseBody);
            }
        }
    }
}
