using FastDo.VivaWallet.Net.Services;
using FastDo.VivaWallet.Net.Tests.Mocks;

namespace FastDo.VivaWallet.Net.Tests.IntegrationTests
{
    public class VivaWalletServiceTests
    {
        private readonly IVivaWalletService _vivaWalletService;

        public VivaWalletServiceTests()
        {
            var settings = DataMocker.CreateMockVivaWalletServiceSettings();

            _vivaWalletService = new VivaWalletService(settings);
        }

        [Fact]
        public async Task GetAccessToken_Ok()
        {
            var result = await _vivaWalletService.GetAccessToken();

            Assert.True(result.Success);
            Assert.NotNull(result.Value);

            var value = result.Value;
            Assert.NotEmpty(value.Token);
            Assert.NotEmpty(value.TokenType);
            Assert.NotEmpty(value.Scope);
        }
    }
}
