using System.Collections.Generic;
using System.IO;
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
        private readonly AppConfig _config;
        private readonly IDeserializer _deserializer;

        public KeywordService(
            IOptions<AppConfig> config,
            Settings settings)
        {
            _config = config.Value;
            _settings = settings;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }
        
        public List<Keyword> Read()
        {
            var file = Path.Combine(
                _config.DataFolder,
                _settings.KeywordsFile);
            var text = System.IO.File.ReadAllText(file);
            return _deserializer.Deserialize<List<Keyword>>(text);
        }
    }
}