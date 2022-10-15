using FastDo.VivaWallet.Net.Services;

namespace FastDo.VivaWallet.Net.Tests.Mocks
{
    public static class DataMocker
    {
        public static VivaWalletServiceSettings CreateMockVivaWalletServiceSettings() => new VivaWalletServiceSettings()
        {
            AccountsBaseUrl = "https://demo-accounts.vivapayments.com",
            ApiBaseUrl = "https://demo-api.vivapayments.com",
            ClientId = "k6qtgjg32x4advs1e15834ysnek5z2589w4xi9qg3sse3.apps.vivapayments.com",
            ClientSecret = "CQtOvA8BficCU0t80buW5178D6610Q",
        };
    }
}
