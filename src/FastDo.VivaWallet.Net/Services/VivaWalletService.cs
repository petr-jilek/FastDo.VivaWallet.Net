using System.Net;
using System.Text.Json;
using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.Identity;
using RestSharp;
using RestSharp.Authenticators;

namespace FastDo.VivaWallet.Net.Services
{
    public class VivaWalletService : IVivaWalletService
    {
        private readonly VivaWalletServiceSettings _settings;
        private readonly RestClient _accountsRestClient;
        private readonly RestClient _apiRestClient;

        public VivaWalletService(VivaWalletServiceSettings settings)
        {
            _settings = settings;

            _accountsRestClient = new RestClient(new Uri(_settings.AccountsBaseUrl));
            _apiRestClient = new RestClient(new Uri(_settings.ApiBaseUrl));
        }

        private Result<T> ProcessResponse<T>(RestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.Content is null)
                    return Result<T>.Error("Error with no content");
                return Result<T>.Error(response.Content);
            }

            if (typeof(T) == typeof(EmptyClass))
                return Result<T>.Ok();

            if (response.Content is null)
                return Result<T>.Error("Error with no content");

            try
            {
                var data = JsonSerializer.Deserialize<T>(response.Content);
                return Result<T>.Ok(data);
            }
            catch (Exception)
            {
                return Result<T>.Error(response.Content);
            }
        }

        public async Task<Result<AccessToken>> GetAccessToken()
        {
            var restRequest = new RestRequest(@"/connect/token", Method.Post);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);

            var authenticator = new HttpBasicAuthenticator(_settings.ClientId, _settings.ClientSecret);
            await authenticator.Authenticate(_accountsRestClient, restRequest);

            var response = await _accountsRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<AccessToken>(response);
        }
    }
}
