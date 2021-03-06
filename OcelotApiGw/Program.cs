using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder.ConfigureServices(services =>
            {
                services.AddSingleton(builder);
            })
            .ConfigureAppConfiguration(builder =>
            {
                builder.AddJsonFile(Path.Combine("configuration", "configuration.json"));
            })
            .UseStartup<Startup>();

            var host = builder.Build();

            return host;
        }
    }
}
