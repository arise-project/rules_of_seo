using rules_of_seo.Config;
using rules_of_seo.Service;
using rules_of_seo.Validation;
using rules_of_seo.Validation.Interfaces;
using rules_of_seo.Validation.Rules;
using rules_of_seo.Validation.Rules.Interface;
using rules_of_seo.Service.Interface;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using rules_of_seo.Service.Interfaces;

namespace rules_of_seo
{
    public static class Startup
    {
        private static IConfiguration? configuration;

        public static void Configuration(IConfigurationBuilder configBuilder)
        {
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("appsettings.json", optional: true);
            configBuilder.AddEnvironmentVariables(prefix: "APPSETTING_");
            configuration = configBuilder.Build();
        }

        public static void Services(IServiceCollection services)
        {
            services.Configure<AppConfig>(configuration?.GetSection("App"));

            //config services
            services.AddSingleton<IRuleService, RuleService>();
            services.AddSingleton<ISlugService, SlugService>();
            var settings = BuildSettings();
            if (settings == null)
            {
                throw new Exception("can not read settings");
            }

            services.AddSingleton((f) => settings);

            //data services
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<IKeywordService, KeywordService>();
            services.AddSingleton<ICompetitorService, CompetitorService>();
            services.AddSingleton<ICompetitorKeywordsService, CompetitorKeywordsService>();
            services.AddSingleton<ISeoRepository, SeoRepository>();

            //rule validation
            services.AddSingleton<IAllowAdditionParagraphValidator, AllowAdditionParagraphValidator>();
            services.AddSingleton<ICheckPlagiatValidator, CheckPlagiatValidator>();
            services.AddSingleton<ICompetitorsMixValidator, CompetitorsMixValidator>();
            services.AddSingleton<IEndKeywordValidator, EndKeywordValidator>();
            services.AddSingleton<IFirstIncludeOthersValidator, FirstIncludeOthersValidator>();
            services.AddSingleton<IIsKeywordValidator, IsKeywordValidator>();
            services.AddSingleton<IIsUrlValidator, IsUrlValidator>();
            services.AddSingleton<IMaxCompetitorLengthValidator, MaxCompetitorLengthValidator>();
            services.AddSingleton<IMaxKeywordsValidator, MaxKeywordsValidator>();
            services.AddSingleton<IMaxLengthValidator, MaxLengthValidator>();
            services.AddSingleton<IMiddleKeywordValidator, MiddleKeywordValidator>();
            services.AddSingleton<IMinKeywordsValidator, MinKeywordsValidator>();
            services.AddSingleton<IMinLengthValidator, MinLengthValidator>();
            services.AddSingleton<IRefValidator, RefValidator>();
            services.AddSingleton<IStartKeywordValidator, StartKeywordValidator>();
            services.AddSingleton<IUniqueValidator, UniqueValidator>();

            //engine services
            services.AddSingleton<IValidationUnit, ValidationUnit>();
            services.AddSingleton<IValidator, Validator>();
            services.AddHostedService<Worker>();
        }

        private static Settings? BuildSettings()
        {
            try
            {
                string text = File.ReadAllText("./RuleSettings.yml");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Rule Settings:");
                Console.WriteLine(text);
                Console.WriteLine("----------------------------------");
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var settings = deserializer.Deserialize<Settings>(text);
                return settings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}
