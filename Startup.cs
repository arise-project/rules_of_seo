using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rules_of_seo.Config;
using rules_of_seo.Service;
using rules_of_seo.Service.Inerface;
using rules_of_seo.Validation;
using rules_of_seo.Validation.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
            services.Configure<AppConfig>(configuration.GetSection("App"));
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<IRuleService, RuleService>();
            services.AddSingleton<IRuleValidatorService, RuleValidatorService>();
            services.AddSingleton<ISlugService, SlugService>();
            services.AddSingleton<IValidationUnit, ValidationUnit>();
            services.AddSingleton<IValidator, Validator>();

            //Services DI
            
            services.AddSingleton((f) => BuildSettings());
            
            services.AddHostedService<Worker>();
        }
        
        private static Settings BuildSettings()
        {
            string text = File.ReadAllText(@"RuleSettings.yml");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Rule Settings:");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------");
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var settings  = deserializer.Deserialize<Settings>(text);
            return settings;
        }
    }
}
