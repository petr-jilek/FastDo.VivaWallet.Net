using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Subscriptions
{
    public class UpdateSubscriptionResponse
    {
        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }
    }
}
