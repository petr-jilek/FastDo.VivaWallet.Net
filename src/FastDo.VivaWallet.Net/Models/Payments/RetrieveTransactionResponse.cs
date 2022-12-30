using System.Text.Json.Serialization;

namespace FastDo.VivaWallet.Net.Models.Payments
{
    public class RetrieveTransactionResponse
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }

        [JsonPropertyName("orderCode")]
        public long OrderCode { get; set; }

        [JsonPropertyName("statusId")]
        public string? StatusId { get; set; }

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        [JsonPropertyName("insDate")]
        public DateTime InsDate { get; set; }

        [JsonPropertyName("cardNumber")]
        public string? CardNumber { get; set; }

        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("customerTrns")]
        public string? CustomerTrns { get; set; }

        [JsonPropertyName("merchantTrns")]
        public string? MerchantTrns { get; set; }

        [JsonPropertyName("transactionTypeId")]
        public int TransactionTypeId { get; set; }

        [JsonPropertyName("recurringSupport")]
        public bool RecurringSupport { get; set; }

        [JsonPropertyName("totalInstallments")]
        public int TotalInstallments { get; set; }

        [JsonPropertyName("cardCountryCode")]
        public string? CardCountryCode { get; set; }

        [JsonPropertyName("cardIssuingBank")]
        public string? CardIssuingBank { get; set; }

        [JsonPropertyName("currentInstallment")]
        public int CurrentInstallment { get; set; }

        [JsonPropertyName("cardUniqueReference")]
        public string? CardUniqueReference { get; set; }

        [JsonPropertyName("cardTypeId")]
        public int CardTypeId { get; set; }

        [JsonPropertyName("digitalWalletId")]
        public int DigitalWalletId { get; set; }
    }
}
