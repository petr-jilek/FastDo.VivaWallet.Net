namespace FastDo.VivaWallet.Net.Models.Wallet
{
    public class RetrieveWalletResponse
    {
        public string? Iban { get; set; }
        public int WalletId { get; set; }
        public bool IsPrimary { get; set; }
        public decimal Amount { get; set; }
        public decimal Available { get; set; }
        public decimal Overdraft { get; set; }
        public string? FriendlyName { get; set; }
        public int CurrencyCode { get; set; }
    }
}
