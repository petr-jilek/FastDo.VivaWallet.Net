using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Transactions
{
    public class CreateCardTokenRequest
    {
        [JsonPropertyName("transactionId")]
        public string? TransactionId { get; set; }
    }
}
