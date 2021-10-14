using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Serivces.Base;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            // builder.Services.AddHttpClient<IBaseClient, BaseClient>
            builder.Services.AddHttpClient<IClient, Client>(_ =>

                new Client(

                    "https://localhost:44373",

                    new HttpClient

                    {

                        BaseAddress = new Uri("https://localhost:44373")

                    }

                )

             );
            builder.Services.AddScoped<Serivces.Student.StudentService>();
            await builder.Build().RunAsync();
        }
    }
}
