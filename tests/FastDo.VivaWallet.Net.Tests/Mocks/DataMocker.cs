using FastDo.VivaWallet.Net.Services;

namespace FastDo.VivaWallet.Net.Tests.Mocks
{
    public static class DataMocker
    {
        public static VivaWalletServiceSettings CreateMockVivaWalletServiceSettings() => new()
        {
            AccountsBaseUrl = "https://demo-accounts.vivapayments.com",
            ApiBaseUrl = "https://demo-api.vivapayments.com",
            BaseUrl = "https://demo.vivapayments.com",
            ClientId = "g6y8jxb2bxp8rdjej8cdtl1i23s9ckhkheyvuvq1yji12.apps.vivapayments.com",
            ClientSecret = "GUOP4xaz3B8Le9JLR6vYR1axf8w6mE",
            MerchantId = "7e8c90a1-b3fc-47e7-879e-a6ef299f71b5",
            ApiKey = "V0Zc.Q",
        };
    }
}
