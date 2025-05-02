using BlazorPokedex.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPokedex.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Carga appsettings.json y appsettings.{Environment}.json automáticamente
            // Leer aquí la clave "PokeApiBaseAddress" (o usar BaseAddress si no existe)
            var pokeApiBase = builder.Configuration["PokeApiBaseAddress"]
                             ?? builder.HostEnvironment.BaseAddress;

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(pokeApiBase) });

            builder.Services.AddScoped<IPokeApiClient, PokeApiClient>();

            await builder.Build().RunAsync();
        }
    }
}
