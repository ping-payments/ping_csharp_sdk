using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record KlarnaHppOptions
    {
        public KlarnaHppOptions(string pageTitle, Uri logoUrl, List<KlarnaPaymentMethodCategoryEnum> paymentMethodCategories, KlarnaPaymentMethodCategoryEnum paymentMethodCategory, KlarnaPurchaseTypeEnum purchaseType, List<KlarnaBackgroundImage> backgroundImages = null, KlarnaShowSubtotalDetailEnum? showSubtotalDetail = null)
        {
            PageTitle = pageTitle;
            LogoUrl = logoUrl;
            PaymentMethodCategories = paymentMethodCategories;
            PaymentMethodCategory = paymentMethodCategory;
            PurchaseType = purchaseType;
            BackgroundImages = backgroundImages;
            ShowSubtotalDetail = showSubtotalDetail;
        }

        public KlarnaHppOptions()
        {

        }

        /// <summary>
        /// List of Images to use for the background. Best matching resolution will be used.
        /// </summary>
        [JsonPropertyName("background_images")]
        public List<KlarnaBackgroundImage> BackgroundImages { get; set; }

        /// <summary>
        /// URL of the logo to be displayed
        /// </summary>
        [JsonPropertyName("logo_url")]
        public Uri LogoUrl { get; set; }

        /// <summary>
        /// Title for the Payment Page
        /// </summary>
        [JsonPropertyName("page_title")]
        public string PageTitle { get; set; }

        /// <summary>
        /// Payment Method Categories to show on the Payment Page. All available categories will be given to the customer if none is specified.
        /// </summary>
        [JsonPropertyName("payment_method_categories")]
        public List<KlarnaPaymentMethodCategoryEnum> PaymentMethodCategories { get; set; }

        /// <summary>
        /// Payment Method Category to show on the Payment Page. All available categories will be given to the customer if none is specified.
        /// </summary>
        [JsonPropertyName("payment_method_category")]
        public KlarnaPaymentMethodCategoryEnum PaymentMethodCategory { get; set; }

        /// <summary>
        /// Payment Method Category to show on the Payment Page. All available categories will be given to the customer if none is specified.
        /// </summary>
        [JsonPropertyName("purchase_type")]
        public KlarnaPurchaseTypeEnum PurchaseType { get; set; }

        /// <summary>
        /// Payment Method Category to show on the Payment Page. All available categories will be given to the customer if none is specified.
        /// </summary>
        [JsonPropertyName("show_subtotal_detail")]
        public KlarnaShowSubtotalDetailEnum? ShowSubtotalDetail { get; set; }
    }


}
