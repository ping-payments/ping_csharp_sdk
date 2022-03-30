using System.Net;

namespace PingPayments.PaymentsApi.Shared
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
    }
}
