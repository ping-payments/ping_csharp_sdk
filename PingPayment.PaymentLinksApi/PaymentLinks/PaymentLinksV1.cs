using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
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
        public PaymentLinksV1(Lazy<ListPaymentLinksOperation> listPaymentLinksOperation, Lazy<GetPaymentLinkOperation> getPaymentLinkOperation)
        {
            _listPaymentLinksOperation = listPaymentLinksOperation;
            _getPaymentLinkOperation = getPaymentLinkOperation;

        }

        private readonly Lazy<ListPaymentLinksOperation> _listPaymentLinksOperation;
        private readonly Lazy<GetPaymentLinkOperation> _getPaymentLinkOperation;

        public async Task<PaymentLinksResponse> List()
        {
            var response = await _listPaymentLinksOperation.Value.ExecuteRequest(new EmptyRequest());
            return response;
        }

        public async Task<PaymentLinkResponse> Get(Guid paymentLinkID)
        {
            var response = await _getPaymentLinkOperation.Value.ExecuteRequest(paymentLinkID);
            return response;
        }
    }
}

