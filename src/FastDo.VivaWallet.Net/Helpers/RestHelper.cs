using System.Text.Json;
using RestSharp;

namespace FastDo.VivaWallet.Net.Helpers
{
    public static class RestHelper
    {
        public static RestRequest CreateAcceptJsonRestRequest(string url, Method method)
        {
            var restRequest = new RestRequest(url, method)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("Accept", "application/json");

            return restRequest;
        }

        public static RestRequest CreateAcceptJsonPostRestRequest<T>(string url, T body)
        {
            var request = CreateAcceptJsonRestRequest(url, Method.Post);

            var jsonData = JsonSerializer.Serialize(body);
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);

            return request;
        }

        public static RestRequest CreateAcceptJsonPutRestRequest<T>(string url, T body)
        {
            var request = CreateAcceptJsonRestRequest(url, Method.Put);

            var jsonData = JsonSerializer.Serialize(body);
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);

            return request;
        }
    }
}
