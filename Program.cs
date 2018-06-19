using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace KenticoCloudNETCoreDockerDemo1
{
    public class Program
    {
        // This constant must match <UserSecretsId> value in KenticoCloudNETCoreDockerDemo1.csproj
        public const string USER_SECRETS_ID = "KenticoCloudNETCoreDockerDemo1";

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    // delete all default configuration providers
                    config.Sources.Clear();
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddUserSecrets(USER_SECRETS_ID)
                    .AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    if (hostingContext.HostingEnvironment.IsDevelopment())
                    {
                        logging.AddDebug();
                    }
                })
              .UseStartup<Startup>()
              .UseUrls("http://0.0.0.0:80")
              .Build();
    }
}
