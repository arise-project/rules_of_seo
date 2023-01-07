using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace rules_of_seo.Service
{
    public class CompetitorKeywordsService : ICompetitorKeywordsService
    {
        private readonly Settings _settings;
        private readonly ILogger<CompetitorKeywordsService> logger;
        private readonly AppConfig _config;
        private readonly IDeserializer _deserializer;

        public CompetitorKeywordsService(
            IOptions<AppConfig> config,
            Settings settings,
            ILogger<CompetitorKeywordsService> logger)
        {
            _config = config.Value;
            _settings = settings;
            this.logger = logger;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }

        public List<string> Read(string app)
        {
            if (string.IsNullOrWhiteSpace(_config.DataFolder))
            {
                logger.LogError("Set Config DataFolder");
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(_settings.CompetitorKeywordsFile))
            {
                logger.LogError("Set Settings CompetitorKeywordsFile");
                throw new Exception();
            }

            var file = Path.Combine(
                _config.DataFolder,
                app,
                _settings.CompetitorKeywordsFile);

            var text = File.ReadAllText(file);
            return _deserializer.Deserialize<List<string>>(text);
        }
    }
}