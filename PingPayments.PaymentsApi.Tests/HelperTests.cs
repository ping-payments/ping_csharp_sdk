using PingPayments.PaymentsApi.Helpers;
using Xunit;

namespace PingPayments.PaymentsApi.Tests
{
    public class HelperTests
    {
        [Theory]
        [InlineData(1337, 133700)]
        [InlineData(10, 1000)]
        [InlineData(1, 100)]
        [InlineData(0, 0)]
        public void ToMinorCurrency_int_tests(int input, int expected) => Assert.Equal(expected, input.ToMinorCurrencyUnit());

        [Theory]
        [InlineData(1337d, 133700)]
        [InlineData(10d, 1000)]
        [InlineData(1d, 100)]
        [InlineData(0d, 0)]
        public void ToMinorCurrency_double_tests(double input, int expected) => Assert.Equal(expected, input.ToMinorCurrencyUnit());

        [Theory]
        [InlineData(1337, 133700)]
        [InlineData(10, 1000)]
        [InlineData(1, 100)]
        [InlineData(0, 0)]
        public void ToMinorCurrency_decimals_tests(decimal input, int expected) => Assert.Equal(expected, input.ToMinorCurrencyUnit());

        [Theory]
        [InlineData(133700, 1337)]
        [InlineData( 1000, 10)]
        [InlineData( 100, 1)]
        [InlineData(0, 0)]
        public void FromMinorCurrency_tests(int input, decimal expected) => Assert.Equal(expected, input.FromMinorCurrencyUnit());
    }
}
