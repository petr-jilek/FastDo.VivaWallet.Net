﻿using System.Net;
using System.Text.Json;
using System.Xml;
using FastDo.VivaWallet.Net.Helpers;
using FastDo.VivaWallet.Net.Models.Core;
using FastDo.VivaWallet.Net.Models.Identity;
using FastDo.VivaWallet.Net.Models.Payments;
using FastDo.VivaWallet.Net.Models.Subscriptions;
using RestSharp;
using RestSharp.Authenticators;

namespace FastDo.VivaWallet.Net.Services
{
    public class VivaWalletService : IVivaWalletService
    {
        private readonly VivaWalletServiceSettings _settings;

        private readonly RestClient _accountsRestClient;
        private readonly RestClient _apiRestClient;

        private AccessToken? _accessToken;

        public VivaWalletService(VivaWalletServiceSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrEmpty(_settings.AccountsBaseUrl))
                throw new ArgumentNullException(nameof(_settings));
            if (string.IsNullOrEmpty(_settings.ApiBaseUrl))
                throw new ArgumentNullException(nameof(_settings));

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
            var restRequest = new RestRequest(@"/connect/token", Method.Post)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);

            if (string.IsNullOrEmpty(_settings.ClientId))
                throw new ArgumentNullException(nameof(_settings));
            if (string.IsNullOrEmpty(_settings.ClientSecret))
                throw new ArgumentNullException(nameof(_settings));

            var authenticator = new HttpBasicAuthenticator(_settings.ClientId, _settings.ClientSecret);
            await authenticator.Authenticate(_accountsRestClient, restRequest);

            var response = await _accountsRestClient.ExecuteAsync(restRequest);
            var result = ProcessResponse<AccessToken>(response);

            _accessToken = result.Value;

            return result;
        }

        public async Task<Result<CreatePaymentOrderResponse>> CreatePaymentOrderAsync(CreatePaymentOrderRequest requestBody)
        {
            if (_accessToken is null || _accessToken.Token is null)
                return Result<CreatePaymentOrderResponse>.Error("You must obtain access_token first");

            var restRequest = RestHelper.CreateAcceptJsonPostRestRequest("/checkout/v2/orders", requestBody);

            var authenticator = new JwtAuthenticator(_accessToken.Token);
            await authenticator.Authenticate(_apiRestClient, restRequest);

            var response = await _apiRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<CreatePaymentOrderResponse>(response);
        }

        public async Task<Result<AddSubscriptionResponse>> AddSubscriptionAsync(AddSubscriptionRequest requestBody)
        {
            if (_accessToken is null || _accessToken.Token is null)
                return Result<AddSubscriptionResponse>.Error("You must obtain access_token first");

            var restRequest = RestHelper.CreateAcceptJsonPostRestRequest("/dataservices/v1/webhooks/subscriptions", requestBody);

            var authenticator = new JwtAuthenticator(_accessToken.Token);
            await authenticator.Authenticate(_apiRestClient, restRequest);

            var response = await _apiRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<AddSubscriptionResponse>(response);
        }

        public async Task<Result<UpdateSubscriptionResponse>> UpdateSubscriptionAsync(string subscriptionId, UpdateSubscriptionRequest requestBody)
        {
            if (_accessToken is null || _accessToken.Token is null)
                return Result<UpdateSubscriptionResponse>.Error("You must obtain access_token first");

            var restRequest = RestHelper.CreateAcceptJsonPutRestRequest($"/dataservices/v1/webhooks/subscriptions/{subscriptionId}", requestBody);

            var authenticator = new JwtAuthenticator(_accessToken.Token);
            await authenticator.Authenticate(_apiRestClient, restRequest);

            var response = await _apiRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<UpdateSubscriptionResponse>(response);
        }

        public async Task<Result<DeleteSubscriptionResponse>> DeleteSubscriptionAsync(string subscriptionId)
        {
            if (_accessToken is null || _accessToken.Token is null)
                return Result<DeleteSubscriptionResponse>.Error("You must obtain access_token first");

            var restRequest = RestHelper.CreateAcceptJsonRestRequest($"/dataservices/v1/webhooks/subscriptions/{subscriptionId}", Method.Delete);

            var authenticator = new JwtAuthenticator(_accessToken.Token);
            await authenticator.Authenticate(_apiRestClient, restRequest);

            var response = await _apiRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<DeleteSubscriptionResponse>(response);
        }

        public async Task<Result<List<ListSubscriptionsItemResponse>>> ListSubscriptionsAsync()
        {
            if (_accessToken is null || _accessToken.Token is null)
                return Result<List<ListSubscriptionsItemResponse>>.Error("You must obtain access_token first");

            var restRequest = RestHelper.CreateAcceptJsonRestRequest("/dataservices/v1/webhooks/subscriptions/", Method.Get);

            var authenticator = new JwtAuthenticator(_accessToken.Token);
            await authenticator.Authenticate(_apiRestClient, restRequest);

            var response = await _apiRestClient.ExecuteAsync(restRequest);
            return ProcessResponse<List<ListSubscriptionsItemResponse>>(response);
        }
    }
}
