using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Transactions
{
    public class CreateCardTokenResponse
    {
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
