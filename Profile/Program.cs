using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace Profile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // webBuilder.ConfigureKestrel((context, options) =>
                    // {
                    //     // IdentityModelEventSource.ShowPII = true; // only for demo
                    //     options.Limits.MinRequestBodyDataRate = null;

                    //     options.Listen(IPAddress.Any, 5003);
                    //     options.Listen(IPAddress.Any, 15003, listenOptions =>
                    //     {
                    //         listenOptions.Protocols = HttpProtocols.Http2;
                    //     });
                    // });
                    webBuilder
                        // .UseUrls("http://*:5003")
                        .UseKestrel(options=>{
                            options.Listen(IPAddress.Any,5003);
                        })
                        .UseStartup<Startup>();
                });
    }
}
