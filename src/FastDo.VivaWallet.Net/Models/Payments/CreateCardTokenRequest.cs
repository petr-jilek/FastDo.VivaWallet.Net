using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Payments
{
    public class CreateCardTokenRequest
    {
        [JsonPropertyName("transactionId")]
        public string? TransactionId { get; set; }
    }
}
