using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Fast.Template.Start;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            //.WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Debug)
                .WriteTo.File("Logs/debug/logs.txt",
                    fileSizeLimitBytes: 1024 * 1024 * 3,
                    rollOnFileSizeLimit: true,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 100))
            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Information)
                .WriteTo.File("Logs/Information/logs.txt",
                    fileSizeLimitBytes: 1024 * 1024 * 3,
                    rollOnFileSizeLimit: true,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 100))
            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Warning)
                .WriteTo.File("Logs/warning/logs.txt",
                    fileSizeLimitBytes: 1024 * 1024 * 3,
                    rollOnFileSizeLimit: true,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 100))
            .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Error)
                .WriteTo.File("Logs/error/logs.txt",
                    fileSizeLimitBytes: 1024 * 1024 * 3,
                    rollOnFileSizeLimit: true,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 100))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Starting Fast.Template.Start.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<StartHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
