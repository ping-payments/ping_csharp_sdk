using PingPayments.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class AllocationResourceTest : PaymentsApiTestClient
    {
        [Fact]
        public async Task List_Data_returns_200_filter_Disbursement()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(disbursementId: TestData.DisbursementId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_Data_returns_200_filter_Merchant()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(merchantId: TestData.MerchantId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_Data_returns_200_filter_PaymentOrder()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(paymentOrderId: TestData.OrderId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_Data_returns_200_filter_Payment()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(paymentId: TestData.PaymentId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_Data_returns_200_filter_Payout()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(payoutId: TestData.PayoutId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_Page_returns_200()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPage();
            AssertHttpOK(allocationsResponse);
            Assert.NotNull(allocationsResponse.Body!.SuccessfulResponseBody!.PaginationLinks.Current);
        }

        [Fact]
        public async Task List_Page_returns_200_has_next()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPage(limit: 1);
            AssertHttpOK(allocationsResponse);
            Assert.NotNull(allocationsResponse.Body!.SuccessfulResponseBody!.PaginationLinks.Next);
        }

        [Fact]
        public async Task List_Page_returns_422()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPage(limit: -1);
            AssertHttpUnprocessableEntity(allocationsResponse);
        }

    }
}
