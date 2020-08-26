using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Helpers
{
    public interface IDisplayToast
    {
        ValueTask Show(string message, string messageType);
    }
}
