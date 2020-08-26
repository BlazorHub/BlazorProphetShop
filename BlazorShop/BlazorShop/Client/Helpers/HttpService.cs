using BlazorShop.Shared.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Helpers
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponse<T>> Get<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);

            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHttp, defaultJsonSerializerOptions);

                return new HttpResponse<T>(response, true, responseHttp);
            }
            else
            {
                return new HttpResponse<T>(default, false, responseHttp);
            }
        }

        public async Task<HttpResponse<object>> Post<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);

            return new HttpResponse<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponse<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new HttpResponse<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new HttpResponse<TResponse>(default, false, response);
            }
        }

        public async Task<HttpResponse<object>> Put<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, stringContent);
            
            return new HttpResponse<object>(null, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponse<object>> Delete(string url)
        {
            var responseHTTP = await _httpClient.DeleteAsync(url);

            return new HttpResponse<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
