using PingPayments.Shared;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Cancel.V1;


namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public class PaymentLinksV1 : IPaymentLinksV1
    {
        public PaymentLinksV1
            (
                Lazy<ListPaymentLinksOperation> listPaymentLinksOperation, 
                Lazy<CreatePaymentLinkOperation> createPaymentLinkOperation, 
                Lazy<GetPaymentLinkOperation> getPaymentLinkOperation, 
                Lazy<CancelPaymentLinkOperation> cancelPaymentLinkOperation,
                Lazy<SendPaymentLinkOperation> sendPaymentLinkOperation
            )
        {
            _listPaymentLinksOperation = listPaymentLinksOperation;
            _createPaymentLinkOperation = createPaymentLinkOperation;
            _getPaymentLinkOperation = getPaymentLinkOperation;
            _cancelPaymentLinkOperation = cancelPaymentLinkOperation;
            _sendPaymentLinkOperation = sendPaymentLinkOperation;
        }

        private readonly Lazy<ListPaymentLinksOperation> _listPaymentLinksOperation;
        private readonly Lazy<CreatePaymentLinkOperation> _createPaymentLinkOperation;
        private readonly Lazy<GetPaymentLinkOperation> _getPaymentLinkOperation;
        private readonly Lazy<CancelPaymentLinkOperation> _cancelPaymentLinkOperation;
        private readonly Lazy<SendPaymentLinkOperation> _sendPaymentLinkOperation;

        public async Task<PaymentLinksResponse> List() => 
            await _listPaymentLinksOperation.Value.ExecuteRequest(new EmptyRequest());

        public async Task<CreatePaymentLinkResponse> Create(CreatePaymentLinkRequest createPaymentLinkRequest) =>  
            await _createPaymentLinkOperation.Value.ExecuteRequest(createPaymentLinkRequest);

        public async Task<PaymentLinkResponse> Get(Guid paymentLinkID) => 
            await _getPaymentLinkOperation.Value.ExecuteRequest(paymentLinkID);

        public async Task<EmptyResponse> Cancel(Guid paymentLinkID) =>
            await _cancelPaymentLinkOperation.Value.ExecuteRequest(paymentLinkID);

        public async Task<EmptyResponse> Send(Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody) =>
            await _sendPaymentLinkOperation.Value.ExecuteRequest((paymentLinkID, sendPaymentLinkRequestBody));
    }
}

