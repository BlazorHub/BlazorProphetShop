using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorShop.Client.Helpers;
using BlazorShop.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorShop.Client.Repositories.Users;
using BlazorShop.Client.Repositories.Products;
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

            // Radzen
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();

            // HTTP Service
            builder.Services.AddScoped<IHttpService, HttpService>();

            // Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Authentication
            builder.Services.AddScoped<JwtAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());
            builder.Services.AddScoped<ILoginService, JwtAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());

            // Authorization
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
