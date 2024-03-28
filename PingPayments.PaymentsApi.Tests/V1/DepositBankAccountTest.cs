using PingPayments.Mimic.Deposit.Create.V1;
using PingPayments.PaymentsApi.DepositBankAccount.BankTransfer.Connect.Request.V1;
using PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Request.V1;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Tests;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tests.V1
{
    public class DepositBankAccountTest : PaymentsApiTestClient
    {

        [Fact(Skip = "Needs to be tested manually atm")]
        public async Task Can_connect_bank_transfer()
        {
            var paymentRequest = CreatePayment.PingDeposit.Ocr(
                currency: CurrencyEnum.SEK,
                orderItems: new OrderItem[]{
                    new OrderItem(1000, "stuff", SwedishVat.Vat12, TestData.MerchantId)
                },
                completeWhenFunded: true
                );
            PingDepositResponseBody paymentResponse = await _api.Payments.V1.Initiate(TestData.OrderId, paymentRequest);

            //1. Get all deposit bank accounts
            var listBankAccountsResponse = await _api.DepositBankAccount.V1.List();
            AssertHttpOK(listBankAccountsResponse);

            var bankAccounts = listBankAccountsResponse.Body?.SuccessfulResponseBody;
            var bankAccount = bankAccounts[0];

            //2. Get all bank transfers
            var filterParams = new ListBankTransfersRequest();

            var listBankTransfersResult = await _api.DepositBankAccount.V1.ListBankTransfers(bankAccount.Id, filterParams);
            AssertHttpOK(listBankTransfersResult);

            var bankTransfers = listBankTransfersResult.Body?.SuccessfulResponseBody;
            var bankTransfer = bankTransfers.Data[1];

            //3. Make Connection
            var connection_request = new ConnectBankTransferRequest
            {
                ConnectedBy = "Ludde",
                PaymentId = paymentResponse.Id
            };
            var response = await _api.DepositBankAccount.V1.ConnectBankTransfer(bankAccount.Id, bankTransfer.Id, connection_request);
            AssertHttpNoContent(response);

        }
    }
}
