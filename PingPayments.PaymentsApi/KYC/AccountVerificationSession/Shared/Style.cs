using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared
{
    public record Style : BaseStyle
    {
        [JsonPropertyName("back_btn")]
        public Button? BackButton { get; set; }

        [JsonPropertyName("cancel_btn")]
        public Button? CancelButton { get; set; }

        [JsonPropertyName("success_modal")]
        public Modal? SuccessModal { get; set; }

        [JsonPropertyName("invalid_link_modal")]
        public Modal? InvalidLinkModal { get; set; }

        [JsonPropertyName("list_item")]
        public ListStyle? ListItem { get; set; }

        [JsonPropertyName("search_bar")]
        public SearchBar? SearchBar { get; set; }

        [JsonPropertyName("modal_background_color")]
        public string? ModalBackgroundColor { get; set; }

        [JsonPropertyName("spinner_color")]
        public string? SpinnerColor { get; set; }

        [JsonPropertyName("text_color")]
        public string? TextColor { get; set; }
    }
}
