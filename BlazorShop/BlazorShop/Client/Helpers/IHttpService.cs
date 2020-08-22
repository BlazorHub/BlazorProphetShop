using BlazorShop.Shared.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Helpers
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> Get<T>(string url);
        Task<HttpResponse<object>> Post<T>(string url, T data);
        Task<HttpResponse<TResponse>> Post<T, TResponse>(string url, T data);
    }
}
