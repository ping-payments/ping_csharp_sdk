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
            var allocationsResponse = await _api.Allocation.V1.ListDisbursement(TestData.DisbursementId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_Merchant()
        {
            var allocationsResponse = await _api.Allocation.V1.ListMerchant(TestData.MerchantId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_PaymentOrder()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPaymentOrder(TestData.OrderId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_Payment()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPayment(TestData.PaymentId);
            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task List_returns_200_with_filter_Payout()
        {
            var allocationsResponse = await _api.Allocation.V1.ListPayout(TestData.PayoutId);
            AssertHttpOK(allocationsResponse);
        }
    }
}
