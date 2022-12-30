namespace FastDo.VivaWallet.Net.Models.Webhooks
{
    public class TransactionPriceCalculatedBody
    {
        public string? Url { get; set; }
        public TransactionPriceCalculatedEventData? EventData { get; set; }
        public DateTime Created { get; set; }
        public string? CorrelationId { get; set; }
        public int EventTypeId { get; set; }
        public string? Delay { get; set; }
        public string? MessageId { get; set; }
        public string? RecipientId { get; set; }
        public int MessageTypeId { get; set; }
    }
}
