using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record KlarnaBackgroundImage
    {
        public KlarnaBackgroundImage(int height, int width, Uri url)
        {
            Height = height;
            Width = width;
            Url = url;
        }

        public KlarnaBackgroundImage()
        {

        }

        /// <summary>
        /// Height of the image in pixels
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// Width of the image in pixels
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        /// URL of the background image
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }


}
