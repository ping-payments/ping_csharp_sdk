using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.Allocations.V1;
using PingPayments.PaymentsApi.PaymentOrders.Close.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Settle.V1;
using PingPayments.PaymentsApi.PaymentOrders.Split.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession
{
    public class AccountVerificationSessionV1 : IAccountVerificationSessionV1
    {
        public AccountVerificationSessionV1
            (
                Lazy<GetSessionOperation> getSessionOperation,
                Lazy<CreateSessionOperation> createSessionOperation
            )
        {
            _getSessionOperation = getSessionOperation;
            _createSessionOperation = createSessionOperation;

        }

        private readonly Lazy<GetSessionOperation> _getSessionOperation;
        private readonly Lazy<CreateSessionOperation> _createSessionOperation;

        public async Task<GetSessionResponse> Get(string sessionId) =>
            await _getSessionOperation.Value.ExecuteRequest(sessionId);

        public async Task<CreateSessionResponse> Create(CreateSessionRequest createSessionRequest) =>
            await _createSessionOperation.Value.ExecuteRequest(createSessionRequest);
    }
}
