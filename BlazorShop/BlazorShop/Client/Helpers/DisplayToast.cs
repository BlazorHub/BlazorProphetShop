using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Helpers
{
    class DisplayToast : IDisplayToast
    {
        private readonly IJSRuntime _js;

        public DisplayToast(IJSRuntime js)
        {
            _js = js;
        }

        public async ValueTask Show(string message, string messageType)
        {
            switch (messageType)
            {
                case "success":
                {
                    await _js.InvokeVoidAsync("toastr.success", message);
                    break;
                }
                case "warning":
                {
                    await _js.InvokeVoidAsync("toastr.warning", message);
                    break;
                }
                case "error":
                {
                    await _js.InvokeVoidAsync("toastr.error", message);
                    break;
                }
                default:
                {
                    await _js.InvokeVoidAsync("toastr.success", message);
                    break;
                }
            }
        }
    }
}
