using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public class PaymentLinksV1 : IPaymentLinksV1
    {
        public PaymentLinksV1(Lazy<ListPaymentLinksOperation> listPaymentLinksOperation)
        {
            _listPaymentLinksOperation = listPaymentLinksOperation; 
        }

        private readonly Lazy<ListPaymentLinksOperation> _listPaymentLinksOperation;

        public async Task<PaymentLinksResponse> List()
        {
            var response = await _listPaymentLinksOperation.Value.ExecuteRequest(new EmptyRequest());
            return response;
        }
    }
}
