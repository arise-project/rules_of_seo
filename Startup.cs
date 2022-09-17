using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rules_of_seo.Config;

namespace rules_of_seo
{
    public static class Startup
    {
        private static IConfiguration configuration;
        
        public static void Configuration(HostBuilderContext hostBuilder, IConfigurationBuilder configBuilder)
        {
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("appsettings.json", optional: true);
            configBuilder.AddEnvironmentVariables(prefix: "APPSETTING_");
            configuration = configBuilder.Build();
        }
        
        public static void Services(IServiceCollection services)
        {
            services.Configure<AppConfiguration>(configuration.GetSection("App"));
            services.AddHostedService<Worker>();
        }
    }
}
