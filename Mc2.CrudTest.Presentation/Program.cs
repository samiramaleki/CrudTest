using Mc2.CrudTest.Persistence.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Mc2.CrudTest.Presentation.Server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();
            try
            {
                Log.Information("Build web host");
                var host = CreateHostBuilder(args).Build();

                host.InitDatabase();

                Log.Information("Starting web host");
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void InitDatabase(this IHost host)
        {
            using var scope = host?.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();

            Log.Information("Migrate Database");
            context.Database.Migrate();

            context.SaveChanges();
        }

    }

}
