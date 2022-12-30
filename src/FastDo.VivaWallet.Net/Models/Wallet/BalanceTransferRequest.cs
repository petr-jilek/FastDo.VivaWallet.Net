using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Wallet
{
    public class BalanceTransferRequest
    {
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("saleTransactionId")]
        public string? SaleTransactionId { get; set; }
    }
}
