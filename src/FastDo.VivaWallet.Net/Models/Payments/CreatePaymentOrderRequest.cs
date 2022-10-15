using System.Text.Json.Serialization;
using FastDo.VivaWallet.Net.Models.Common;

namespace FastDo.VivaWallet.Net.Models.Payments
{
    public class CreatePaymentOrderRequest
    {
        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("customerTrns")]
        public string? CustomerTrns { get; set; } = null;

        [JsonPropertyName("customer")]
        public Customer? Customer { get; set; } = null;

        [JsonPropertyName("paymentTimeOut")]
        public int PaymentTimeOut { get; set; } = 1800;

        [JsonPropertyName("preauth")]
        public bool Preauth { get; set; } = false;

        [JsonPropertyName("allowRecurring")]
        public bool AllowRecurring { get; set; } = false;

        [JsonPropertyName("maxInstallments")]
        public int MaxInstallments { get; set; } = 0;

        [JsonPropertyName("paymentNotification")]
        public bool PaymentNotification { get; set; } = false;

        [JsonPropertyName("tipAmount")]
        public long TipAmount { get; set; } = 0;

        [JsonPropertyName("disableExactAmount")]
        public bool DisableExactAmount { get; set; } = false;

        [JsonPropertyName("disableCash")]
        public bool DisableCash { get; set; } = false;

        [JsonPropertyName("disableWallet")]
        public bool DisableWallet { get; set; } = false;

        [JsonPropertyName("sourceCode")]
        public string SourceCode { get; set; } = "Default";

        [JsonPropertyName("merchantTrns")]
        public string? MerchantTrns { get; set; } = null;

        [JsonPropertyName("tags")]
        public string? Tags { get; set; } = null;

        [JsonPropertyName("cardTokens")]
        public List<string>? CardTokens { get; set; } = null;
    }
}
