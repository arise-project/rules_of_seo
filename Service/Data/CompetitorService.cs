﻿using System;
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
    public class CompetitorService : ICompetitorService
    {
        private readonly Settings _settings;
        private readonly ILogger<CompetitorService> logger;
        private readonly AppConfig _config;
        private readonly IDeserializer _deserializer;

        public CompetitorService(
            IOptions<AppConfig> config,
            Settings settings,
            ILogger<CompetitorService> logger)
        {
            _config = config.Value;
            _settings = settings;
            this.logger = logger;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }

        public List<Competitor> Read(string app)
        {
            if (string.IsNullOrWhiteSpace(_config.DataFolder))
            {
                logger.LogError("Set Config DataFolder");
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(_settings.CompetitorFile))
            {
                logger.LogError("Set Settings CompetitorFile");
                throw new Exception();
            }

            var file = Path.Combine(
                _config.DataFolder,
                app,
                _settings.CompetitorFile);

            var text = File.ReadAllText(file);
            
            try
            {
                return _deserializer.Deserialize<List<Competitor>>(text);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error reading {file}", ex);
            }
        }
    }
}