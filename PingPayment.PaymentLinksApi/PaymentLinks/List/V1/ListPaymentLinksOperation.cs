using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public class ListPaymentLinksOperation : OperationBase<EmptyRequest, PaymentLinksResponse>
    {
        public ListPaymentLinksOperation(HttpClient httpClient) : base(httpClient)
        {
        }

        public override Task<PaymentLinksResponse> ExecuteRequest(EmptyRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<PaymentLinksResponse> ParseHttpResponse(HttpResponseMessage response, EmptyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
