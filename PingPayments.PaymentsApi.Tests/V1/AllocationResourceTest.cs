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
        public async Task List_returns_200_with_filter_Disbursement()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(disbursementId: TestData.DisbursementId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_Merchant()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(merchantId: TestData.MerchantId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_PaymentOrder()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(paymentOrderId: TestData.OrderId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_Payment()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(paymentId: TestData.PaymentId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_Payout()
        {
            var allocationsResponse = await _api.Allocation.V1.ListData(payoutId: TestData.PayoutId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_Page()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPage();
            if (allocationsResponse.IsSuccessful)
            {
                Assert.NotNull(allocationsResponse.Body);
                var responseBody = allocationsResponse.Body!.SuccessfulResponseBody;
                Assert.NotNull(responseBody!.PaginationLinks.Current);
                allocationsResponse = await _api.Allocation.V1.ListPage(responseBody!.PaginationLinks.Current!);
            }
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_Page_has_next()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPage();
            if (allocationsResponse.IsSuccessful)
            {
                Assert.NotNull(allocationsResponse.Body);
                var responseBody = allocationsResponse.Body!.SuccessfulResponseBody;
                if (responseBody!.PaginationLinks.Next != null)
                {
                    Assert.NotNull(responseBody!.PaginationLinks.Next);
                    allocationsResponse = await _api.Allocation.V1.ListPage(responseBody!.PaginationLinks.Next!);
                }
            }
            AssertHttpOK(allocationsResponse);
        }

    }
}
