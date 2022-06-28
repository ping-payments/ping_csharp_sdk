using PingPayments.PaymentLinksApi.PaymentLinks.Cancel.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1;
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
        public PaymentLinksV1(Lazy<ListPaymentLinksOperation> listPaymentLinksOperation, Lazy<GetPaymentLinkOperation> getPaymentLinkOperation, Lazy<CancelPaymentLinkOperation> cancelPaymentLinkOperation, Lazy<SendPaymentLinkOperation> sendPaymentLinkOperation)
        {
            _listPaymentLinksOperation = listPaymentLinksOperation;
            _getPaymentLinkOperation = getPaymentLinkOperation;
            _cancelPaymentLinkOperation = cancelPaymentLinkOperation;
            _sendPaymentLinkOperation = sendPaymentLinkOperation;

        }

        private readonly Lazy<ListPaymentLinksOperation> _listPaymentLinksOperation;
        private readonly Lazy<GetPaymentLinkOperation> _getPaymentLinkOperation;
        private readonly Lazy<CancelPaymentLinkOperation> _cancelPaymentLinkOperation;
        private readonly Lazy<SendPaymentLinkOperation> _sendPaymentLinkOperation;


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

        public async Task<EmptyResponse> Cancel(Guid paymentLinkID) =>
            await _cancelPaymentLinkOperation.Value.ExecuteRequest(paymentLinkID);

        public async Task<EmptyResponse> Send(Guid paymentLinkID) =>
            await _sendPaymentLinkOperation.Value.ExecuteRequest(paymentLinkID);
    }
}

