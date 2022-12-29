using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Subscriptions
{
    public class ListSubscriptionsItemResponse
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }

        [JsonPropertyName("events")]
        public List<string>? Events { get; set; }
    }
}
