namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Item
    {

        public Item(string description, string itemNumber, Guid merchantId, int price, int quantity, string unit, int vat)
        {

            Description = description;
            ItemNumber = itemNumber;
            MerchantId = merchantId;
            Price = price;
            Quantity = quantity;
            Unit = unit;
            Vat = vat;

        }

        public string Description { get; set; }
        public string ItemNumber { get; set; }
        public Guid MerchantId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Vat { get; set; }


        /// <summary>
        /// Simplifies creation of  items array
        /// </summary>
        public static implicit operator Item[](Item Item) => new[] { Item };
    }
}