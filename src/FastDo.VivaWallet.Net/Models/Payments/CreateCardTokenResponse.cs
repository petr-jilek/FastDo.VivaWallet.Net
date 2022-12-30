using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Payments
{
    public class CreateCardTokenResponse
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
