using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NBAInfo.Data.Database;
using NBAInfo.Data.Seeds;
using Serilog;

namespace NBAInfo.Web
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args);
            Log.Logger = new LoggerConfiguration()
                        .CreateLogger();
            //Initialize Database context class.
            using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                //Define your context by retrieving your db context from your service provider.
                using (var dbContext = scope.ServiceProvider.GetRequiredService<NBAInfoContext>())
                {
                    dbContext.Database.Migrate();
                    Log.Information("Information is up to date.");
                }
            }
            ///Initialize services.
            using (var scope = host.Services.CreateScope())
            {
                //Define the services which would initiate the seeding of data.
                var services = scope.ServiceProvider;
                //Have a try/catch block initializing db context.
                try
                {
                    var context = services.GetRequiredService<NBAInfoContext>();
                    //Now seed your data using the context your just defined with your nested using block
                    EnsurePlayerData.Seed(context);
                    EnsureTeamData.Seed(context);
                    EnsureCoachData.Seed(context);
                }
                catch (Exception ex)
                {
                    //Now log your error by passing exception as first argument, and message as second.
                    Log.Error(ex, "Seed Data Error!!!!!!!!!!");
                }
            }
            try
            {
                Log.Information("Host server is running");
                host.Run();
            }
            catch
            {
                Log.Information("Host running Error!!!!!!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
