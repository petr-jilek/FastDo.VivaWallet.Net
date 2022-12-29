using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Subscriptions
{
    public class AddSubscriptionRequest
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("secret")]
        public string? Secret { get; set; }

        [JsonPropertyName("events")]
        public List<string>? Events { get; set; }
    }
}
