namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public static class SwedishVat
    {
        /// <summary>
        /// General tax rate, which applies to most goods and services
        /// </summary>
        public static decimal Vat25 => 25.00m;

        /// <summary>
        /// Charged on foodstuffs, hotels, and artists' own sales of works of art.
        /// </summary>
        public static decimal Vat12 => 12.00m;

        /// <summary>
        ///  Applies to newspapers, magazines, books, passenger transport (taxis, buses, flights and trains) in Sweden and concerts.
        /// </summary>
        public static decimal Vat6 => 06.00m;

        /// <summary>
        ///  applies to financial services, membership fees, and so forth
        /// </summary>
        public static decimal Zero => 00.00m;
    }
}
