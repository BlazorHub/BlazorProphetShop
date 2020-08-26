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

            // Register the Storage event handler. This handler calls OnStorageUpdated when the storage changed.
            // This way, you can reload the settings when another instance of the application (tab / window) save the settings
            if (!_initialized)
            {
                // Create a reference to the current object, so the JS function can call the public method "OnStorageUpdated"
                var reference = DotNetObjectReference.Create(this);
                await _jsRuntime.InvokeVoidAsync("BlazorRegisterStorageEvent", reference);
                _initialized = true;
            }

            // Read the JSON string that contains the data from the local storage
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

            // Register the OnPropertyChanged event, so it automatically persists the settings as soon as a value is changed
            result.PropertyChanged += OnPropertyChanged;
            _order = result;
            return result;
        }

        public async Task Save()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(_order);
            await _jsRuntime.InvokeVoidAsync("BlazorSetLocalStorage", KeyName, json);
        }

        // Automatically persist the settings when a property changed
        private async void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (AutoSave)
            {
                await Save();
            }
        }

        // This method is called from BlazorRegisterStorageEvent when the storage changed
        [JSInvokable]
        public void OnStorageUpdated(string key)
        {
            if (key == KeyName)
            {
                // Reset the settings. The next call to Get will reload the data
                _order = null;
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
