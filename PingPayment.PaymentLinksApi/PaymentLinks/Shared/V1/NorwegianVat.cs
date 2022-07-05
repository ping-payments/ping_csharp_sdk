namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public static class NorwegianVat
    {
        /// <summary>
        /// All other taxable goods and services
        /// </summary>
        public static decimal Standard25 => 25.00m;

        /// <summary>
        /// Foodstuffs and beverages
        /// </summary>
        public static decimal Reduced15 => 15.00m;

        /// <summary>
        /// Supply of raw fish
        /// </summary>
        public static decimal Reduced11Point1 => 11.10m;

        /// <summary>
        /// Certain cultural and sporting activities; transport services
        /// </summary>
        public static decimal Reduced6 => 06.00m;

        /// <summary>
        /// E-books
        /// </summary>
        public static decimal Zero => 00.00m;
    }
}
