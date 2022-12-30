using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.DataServices
{
    public class UpdateSubscriptionResponse
    {
        [JsonPropertyName("subscriptionId")]
        public string? SubscriptionId { get; set; }
    }
}
