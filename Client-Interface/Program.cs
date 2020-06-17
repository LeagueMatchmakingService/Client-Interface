using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely;
using System.Threading;
using System.Reflection;
using Chromely.Core.Network;
using ServerAppDemo.ChromelyControllers;

namespace ServerAppDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appName = Assembly.GetEntryAssembly()?.GetName().Name;
            var firstProcess = ServerAppUtil.IsMainProcess(args);
            var port = ServerAppUtil.AvailablePort;

            if (firstProcess)
            {
                if (port != -1)
                {
                    // start the kestrel server in a background thread
                    var blazorTask = new Task(() => CreateHostBuilder(args, port).Build().Run(), TaskCreationOptions.LongRunning);
                    blazorTask.Start();

                    // wait till its up
                    while (ServerAppUtil.IsPortAvailable(port))
                    {
                        Thread.Sleep(1);
                    }
                }

                // Save port for later use by chromely processes
                ServerAppUtil.SavePort(appName, port);
            }
            else
            {
                // fetch port number
                port = ServerAppUtil.GetSavedPort(appName);
            }

            if (port != -1)
            {
                // start up chromely
                var core = typeof(IChromelyConfiguration).Assembly;
                var config = DefaultConfiguration.CreateForRuntimePlatform();
                config.WindowOptions.Title = "League of legends Matchmaking Service";
                config.StartUrl = $"http://127.0.0.1:{port}";
                config.DebuggingMode = false;
                config.WindowOptions.RelativePathToIconFile = "chromely.ico";

                try
                {
                    var builder = AppBuilder.Create();
                    builder = builder.UseConfiguration<DefaultConfiguration>(config);
                    builder = builder.UseApp<DemoChromelyApp>();
                    builder = builder.Build();
                    builder.Run(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, int port) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>()
                    .UseUrls(new[] { $"http://127.0.0.1:{port}" });
                });
    }

    public class DemoChromelyApp : ChromelyBasicApp
    {
        public override void Configure(IChromelyContainer container)
        {
            base.Configure(container);
            container.RegisterSingleton(typeof(ChromelyController), Guid.NewGuid().ToString(), typeof(MatchmakingController));
        }
    }
}
