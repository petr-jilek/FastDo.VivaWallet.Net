using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.DataServices;
using FastDo.VivaWallet.Net.Models.Identity;
using FastDo.VivaWallet.Net.Models.Payments;
using FastDo.VivaWallet.Net.Models.Wallet;

namespace FastDo.VivaWallet.Net.Services
{
    public interface IVivaWalletService
    {
        Result<string> GetPaymentUrl(long orderCode, string color);
        Task<Result<AccessToken>> GetAccessTokenAsync();
        Task<Result<CreatePaymentOrderResponse>> CreatePaymentOrderAsync(CreatePaymentOrderRequest requestBody);
        Task<Result<RetrieveTransactionResponse>> RetrieveTransactionAsync(string transactionId);
        Task<Result<CreateCardTokenResponse>> CreateCardTokenAsync(CreateCardTokenRequest requestBody);
        Task<Result<BalanceTransferResponse>> BalanceTransferAsync(string walletId, string targetWalletId, BalanceTransferRequest requestBody);
        Task<Result<RetrieveWalletResponse>> RetrieveWalletAsync();
        Task<Result<AddSubscriptionResponse>> AddSubscriptionAsync(AddSubscriptionRequest requestBody);
        Task<Result<UpdateSubscriptionResponse>> UpdateSubscriptionAsync(string subscriptionId, UpdateSubscriptionRequest requestBody);
        Task<Result<DeleteSubscriptionResponse>> DeleteSubscriptionAsync(string subscriptionId);
        Task<Result<List<ListSubscriptionsItemResponse>>> ListSubscriptionsAsync();
    }
}
