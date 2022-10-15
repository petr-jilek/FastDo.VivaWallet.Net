using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.Identity;
using FastDo.VivaWallet.Net.Models.Payments;

namespace FastDo.VivaWallet.Net.Services
{
    public interface IVivaWalletService
    {
        Task<Result<AccessToken>> GetAccessTokenAsync();
        Task<Result<CreatePaymentOrderResponse>> CreatePaymentOrderAsync(CreatePaymentOrderRequest requestBody);
    }
}
