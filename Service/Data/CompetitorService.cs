using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace rules_of_seo.Service
{
    public class CompetitorService : ICompetitorService
    {
        private readonly Settings _settings;
        private readonly AppConfig _config;
        private readonly IDeserializer _deserializer;

        public CompetitorService(
            IOptions<AppConfig> config,
            Settings settings)
        {
            _config = config.Value;
            _settings = settings;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }
        
        public List<Competitor> Read()
        {
            var file = Path.Combine(
                _config.DataFolder,
                _settings.CompetitorFile);
            
            var text = System.IO.File.ReadAllText(file);
            return _deserializer.Deserialize<List<Competitor>>(text);
        }
    }
}