using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Subscriptions
{
    public class AddSubscriptionResponse
    {
        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }
    }
}
