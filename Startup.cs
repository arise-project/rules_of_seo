using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rules_of_seo.Config;
using rules_of_seo.Service;
using rules_of_seo.Service.Inerface;
using rules_of_seo.Validation;
using rules_of_seo.Validation.Interface;

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
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<IRuleService, RuleService>();
            services.AddSingleton<IRuleValidatorService, RuleValidatorService>();
            services.AddSingleton<ISlugService, SlugService>();
            services.AddSingleton<IValidationUnit, ValidationUnit>();
            services.AddSingleton<IValidator, Validator>();
            
            services.AddHostedService<Worker>();
        }
    }
}
