using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace rules_of_seo.Service
{
    public class KeywordService : IKeywordService
    {
        private readonly Settings _settings;
        private readonly ILogger<KeywordService> logger;
        private readonly AppConfig _config;
        private readonly IDeserializer _deserializer;

        public KeywordService(
            IOptions<AppConfig> config,
            Settings settings,
            ILogger<KeywordService> logger)
        {
            _config = config.Value;
            _settings = settings;
            this.logger = logger;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }

        public List<Keyword> Read(string app)
        {
            if (string.IsNullOrWhiteSpace(_config.DataFolder))
            {
                logger.LogError("Set Config DataFolder");
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(_settings.KeywordsFile))
            {
                logger.LogError("Set Settings KeywordsFile");
                throw new Exception();
            }

            var file = Path.Combine(
                _config.DataFolder,
                _settings.KeywordsFile);
            var text = File.ReadAllText(file);
            return _deserializer.Deserialize<List<Keyword>>(text);
        }
    }
}