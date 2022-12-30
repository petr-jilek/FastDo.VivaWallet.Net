using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.DataServices
{
    public class AddSubscriptionResponse
    {
        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }
    }
}
