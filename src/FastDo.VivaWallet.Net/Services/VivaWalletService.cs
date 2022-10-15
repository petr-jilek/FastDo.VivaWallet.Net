using System.Net;
using System.Text.Json;
using System.Xml;
using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.Identity;
using FastDo.VivaWallet.Net.Models.Payments;
using RestSharp;
using RestSharp.Authenticators;

namespace FastDo.VivaWallet.Net.Services
{
    public class VivaWalletService : IVivaWalletService
    {
        private readonly VivaWalletServiceSettings _settings;

        private readonly RestClient _accountsRestClient;
        private readonly RestClient _apiRestClient;

        private AccessToken _accessToken;

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

        public async Task<Result<AccessToken>> GetAccessTokenAsync()
        {
            var restRequest = new RestRequest(@"/connect/token", Method.Post);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);

            var authenticator = new HttpBasicAuthenticator(_settings.ClientId, _settings.ClientSecret);
            await authenticator.Authenticate(_accountsRestClient, restRequest);

            var response = await _accountsRestClient.ExecuteAsync(restRequest);
            var result = ProcessResponse<AccessToken>(response);

            _accessToken = result.Value;

            return result;
        }

        public async Task<Result<CreatePaymentOrderResponse>> CreatePaymentOrderAsync(CreatePaymentOrderRequest requestBody)
        {
            if (_accessToken is null)
                return Result<CreatePaymentOrderResponse>.Error("You must obtain access_token first");

            var restRequest = new RestRequest(@"/checkout/v2/orders", Method.Post);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");

            var authenticator = new JwtAuthenticator(_accessToken.Token);
            await authenticator.Authenticate(_apiRestClient, restRequest);

            var jsonData = JsonSerializer.Serialize(requestBody);
            restRequest.AddParameter("application/json", jsonData, ParameterType.RequestBody);

            var response = await _apiRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<CreatePaymentOrderResponse>(response);
        }
    }
}
