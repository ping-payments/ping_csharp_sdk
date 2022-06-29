using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public record PaymentLinksResponse : ApiResponseBase<PaymentLinkList>
    {
        public PaymentLinksResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentLinkList>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static implicit operator PaymentLink[]?(PaymentLinksResponse paymentLinksResponse) =>
            paymentLinksResponse.IsSuccessful && 
            paymentLinksResponse.Body?.SuccesfulResponseBody != null ?
            paymentLinksResponse.Body.SuccesfulResponseBody.PaymentLinks: null; 

        public static PaymentLinksResponse Succesful(HttpStatusCode statusCode, PaymentLinkList? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentLinksResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
