using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace Nm.Reservation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(baseDirectory, "log/log.txt"))
                .CreateLogger();
            //CreateHostBuilder(args).Build().Run();
            try
            {
                Log.Information("Starting web host");

                CreateHostBuilder(args)
                .Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                .UseStartup<Startup>();

            })
            .UseAutofac();
    }
}
