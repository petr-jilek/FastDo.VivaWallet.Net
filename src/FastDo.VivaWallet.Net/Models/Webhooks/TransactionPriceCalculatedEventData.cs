namespace FastDo.VivaWallet.Net.Models.Webhooks
{
    public class TransactionPriceCalculatedEventData
    {
        public long OrderCode { get; set; }
        public string? MerchantId { get; set; }
        public decimal IsvFee { get; set; }
        public string? TransactionId { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal Interchange { get; set; }
        public decimal TotalCommission { get; set; }
    }
}
