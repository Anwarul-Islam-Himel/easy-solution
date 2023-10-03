using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace EasySolutionHospital.Helper
{
    public interface IHttpService
    {
        Task<T> Get<T>(string url);
        Task<T> Post<T>(string url, object data);
        Task<T> Put<T>(string url, object data);
        Task<T> Delete<T>(string url);
    }
    public class HttpSsaervice : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpSsaervice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> Delete<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            return await SendRequest<T>(request);
        }

        public async Task<T> Get<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return await SendRequest<T>(request);
        }

        public async Task<T> Post<T>(string url, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json")
            };
            return await SendRequest<T>(request);
        }

        public async Task<T> Put<T>(string url, object data)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json")
            };
            return await SendRequest<T>(request);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            using var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
