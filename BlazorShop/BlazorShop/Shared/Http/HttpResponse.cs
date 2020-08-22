using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorShop.Shared.Http
{
    public class HttpResponse<T>
    {
        public HttpResponse()
        {

        }

        public HttpResponse(T data, bool success, HttpResponseMessage message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public HttpResponseMessage Message { get; set; } = null;

        public async Task<string> GetBody()
        {
            return await Message.Content.ReadAsStringAsync();
        }
    }
}
