using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.Identity;

namespace FastDo.VivaWallet.Net.Services
{
    public interface IVivaWalletService
    {
        Task<Result<AccessToken>> GetAccessToken();
    }
}
