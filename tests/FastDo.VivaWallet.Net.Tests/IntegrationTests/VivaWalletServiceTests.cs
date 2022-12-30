using FastDo.VivaWallet.Net.Consts;
using FastDo.VivaWallet.Net.Models.Payments;
using FastDo.VivaWallet.Net.Models.Subscriptions;
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
        public async Task GetAccessTokenAsync_Ok()
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
        public async Task CreatePaymentOrderAsync_Ok()
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

        [Fact(Skip = "Not finished")]
        public async Task AddSubscriptionAsync_Ok()
        {
            await _vivaWalletService.GetAccessTokenAsync();

            var request = new AddSubscriptionRequest()
            {
                Url = "https://www.myapi.com/webhooks/receive",
                Secret = "mysecret",
                Events = new List<string> { WebHooks.TransactionPaymentCreated },
            };

            var result = await _vivaWalletService.AddSubscriptionAsync(request);

            Assert.True(result.Success);
            Assert.NotNull(result.Value);

            var subscriptionId = result.Value.SubscriptionId;

            var listResult = await _vivaWalletService.ListSubscriptionsAsync();

            Assert.True(listResult.Success);
            Assert.NotNull(listResult.Value);
            Assert.Single(listResult.Value);

            Assert.Equal(subscriptionId, listResult.Value.First().SubscriptionId);
            Assert.Equal(request.Url, listResult.Value.First().SubscriptionId);
            for (var i = 0; i < request.Events.Count; i++)
            {
                Assert.Equal(request.Events[i], listResult.Value.First().Events[i]);
            }
        }
    }
}
