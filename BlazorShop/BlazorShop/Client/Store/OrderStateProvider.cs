using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Store
{
    public sealed class OrderStateProvider
    {
        private const string KeyName = "ORDER";

        private readonly IJSRuntime _jsRuntime;
        private bool _initialized;
        private OrderState _order;

        public event EventHandler Changed;

        public bool AutoSave { get; set; } = true;

        public OrderStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async ValueTask<OrderState> Get()
        {
            if (_order != null)
                return _order;

            if (!_initialized)
            {
                var reference = DotNetObjectReference.Create(this);
                await _jsRuntime.InvokeVoidAsync("BlazorRegisterStorageEvent", reference);
                _initialized = true;
            }

            OrderState result;

            var str = await _jsRuntime.InvokeAsync<string>("BlazorGetLocalStorage", KeyName);
            if (str != null)
            {
                result = JsonSerializer.Deserialize<OrderState>(str) ?? new OrderState();
            }
            else
            {
                result = new OrderState();
            }

            result.PropertyChanged += OnPropertyChanged;
            _order = result;
            return result;
        }

        public async Task Save()
        {
            var json = JsonSerializer.Serialize(_order);
            await _jsRuntime.InvokeVoidAsync("BlazorSetLocalStorage", KeyName, json);
        }

        private async void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (AutoSave)
            {
                await Save();
            }
        }

        [JSInvokable]
        public void OnStorageUpdated(string key)
        {
            if (key == KeyName)
            {
                _order = null;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
