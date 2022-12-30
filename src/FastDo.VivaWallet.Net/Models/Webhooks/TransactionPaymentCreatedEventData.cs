namespace FastDo.VivaWallet.Net.Models.Webhooks
{
    public class TransactionPaymentCreatedEventData
    {
        public bool Moto { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? BankId { get; set; }
        public bool Systemic { get; set; }
        public bool Switching { get; set; }
        public string? ParentId { get; set; }
        public decimal Amount { get; set; }
        public string? ChannelId { get; set; }
        public int TerminalId { get; set; }
        public string? MerchantId { get; set; }
        public long OrderCode { get; set; }
        public string? ProductId { get; set; }
        public string? StatusId { get; set; }
        public string? FullName { get; set; }
        public string? ResellerId { get; set; }
        public DateTime InsDate { get; set; }
        public decimal TotalFee { get; set; }
        public string? CardToken { get; set; }
        public string? CardUniqueReference { get; set; }
        public string? CardNumber { get; set; }
        public int TipAmount { get; set; }
        public string? SourceCode { get; set; }
        public string? SourceName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? CompanyName { get; set; }
        public string? TransactionId { get; set; }
        public string? CompanyTitle { get; set; }
        public string? PanEntryMode { get; set; }
        public int ReferenceNumber { get; set; }
        public string? ResponseCode { get; set; }
        public string? CurrencyCode { get; set; }
        public string? OrderCulture { get; set; }
        public string? MerchantTrns { get; set; }
        public string? CustomerTrns { get; set; }
        public bool IsManualRefund { get; set; }
        public string? TargetPersonId { get; set; }
        public string? TargetWalletId { get; set; }
        public bool LoyaltyTriggered { get; set; }
        public byte TotalInstallments { get; set; }
        public string? CardCountryCode { get; set; }
        public string? CardIssuingBank { get; set; }
        public int RedeemedAmount { get; set; }
        public int ClearanceDate { get; set; }
        public byte CurrentInstallment { get; set; }
        public List<string>? Tags { get; set; }
        public string? BillId { get; set; }
        public string? ResellerSourceCode { get; set; }
        public string? ResellerSourceName { get; set; }
        public string? ResellerCompanyName { get; set; }
        public string? ResellerSourceAddress { get; set; }
        public string? CardExpirationDate { get; set; }
        public string? RetrievalReferenceNumber { get; set; }
        public List<string>? AssignedMerchantUsers { get; set; }
        public List<string>? AssignedResellerUsers { get; set; }
        public byte CardTypeId { get; set; }
        public byte DigitalWalletId { get; set; }
        public string? ResponseEventId { get; set; }
        public string? ElectronicCommerceIndicator { get; set; }
    }
}
