using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.Identity;
using FastDo.VivaWallet.Net.Models.Payments;
using FastDo.VivaWallet.Net.Models.Subscriptions;

namespace FastDo.VivaWallet.Net.Services
{
    public interface IVivaWalletService
    {
        Task<Result<AccessToken>> GetAccessTokenAsync();
        Task<Result<CreatePaymentOrderResponse>> CreatePaymentOrderAsync(CreatePaymentOrderRequest requestBody);
        Task<Result<AddSubscriptionResponse>> AddSubscriptionAsync(AddSubscriptionRequest requestBody);
        Task<Result<UpdateSubscriptionResponse>> UpdateSubscriptionAsync(string subscriptionId, UpdateSubscriptionRequest requestBody);
        Task<Result<DeleteSubscriptionResponse>> DeleteSubscriptionAsync(string subscriptionId);
        Task<Result<List<ListSubscriptionsItemResponse>>> ListSubscriptionsAsync();
    }
}
