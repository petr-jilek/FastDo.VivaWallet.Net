using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.DataServices
{
    public class DeleteSubscriptionResponse
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
