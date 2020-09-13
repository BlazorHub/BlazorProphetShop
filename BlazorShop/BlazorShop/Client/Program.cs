using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorShop.Client.Helpers;
using BlazorShop.Client.Auth;
using BlazorShop.Client.Store;
using BlazorShop.Client.Data.Orders;
using BlazorShop.Client.Data.Categories;
using BlazorShop.Client.Data.Users;
using BlazorShop.Client.Data.Products;
using Tewr.Blazor.FileReader;
using Radzen;

namespace BlazorShop.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddFileReaderService(options => options.InitializeOnFirstCall = true);

            // Radzen
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();

            // Store
            builder.Services.AddScoped<OrderStateProvider>();

            // HTTP Service
            builder.Services.AddScoped<IHttpService, HttpService>();

            // Repositories
            builder.Services.AddScoped<IUserClient, UserClient>();
            builder.Services.AddScoped<IProductClient, ProductClient>();
            builder.Services.AddScoped<IOrderClient, OrderClient>();
            builder.Services.AddScoped<ICategoryClient, CategoryClient>();

            // Helpers
            builder.Services.AddScoped<IDisplayToast, DisplayToast>();

            // Authorization
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            // Authentication
            builder.Services.AddScoped<JwtAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());
            builder.Services.AddScoped<ILoginService, JwtAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());

            await builder.Build().RunAsync();
        }
    }
}
