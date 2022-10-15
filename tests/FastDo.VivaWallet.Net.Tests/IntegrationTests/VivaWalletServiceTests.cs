using FastDo.VivaWallet.Net.Models.Payments;
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
            var result = await _vivaWalletService.GetAccessTokenAsync();

            Assert.True(result.Success);
            Assert.NotNull(result.Value);

            var value = result.Value;
            Assert.NotEmpty(value.Token);
            Assert.NotEmpty(value.TokenType);
            Assert.NotEmpty(value.Scope);
            Assert.True(value.ExpiresIn > 0);
        }

        [Fact]
        public async Task CreatePaymentOrder_Ok()
        {
            await _vivaWalletService.GetAccessTokenAsync();

            var request = new CreatePaymentOrderRequest()
            {
                Amount = 500_00,
            };

            var result = await _vivaWalletService.CreatePaymentOrderAsync(request);

            Assert.True(result.Success);
            Assert.NotNull(result.Value);
            var value = result.Value;

            Assert.True(value.OrderCode > 0);
        }
    }
}
