using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;

namespace rules_of_seo.Service
{
    public class SeoRepository : ISeoRepository
    {
        private readonly AppConfig _config;
        private readonly IKeywordService _keywordService;
        private readonly ICompetitorService _competitorService;
        private readonly ICompetitorKeywordsService _competitorKeywordsService;
        private readonly ILogger<SeoRepository> logger;

        public SeoRepository(
               IOptions<AppConfig> config,
               IKeywordService keywordService,
               ICompetitorService competitorService,
               ICompetitorKeywordsService competitorKeywordsService,
               ILogger<SeoRepository> logger)
        {
            _config = config.Value;
            _keywordService = keywordService;
            _competitorService = competitorService;
            _competitorKeywordsService = competitorKeywordsService;

            Apps = new List<string>();
            Keywords = new Dictionary<string, List<Keyword>>();
            Competitors = new Dictionary<string, List<Competitor>>();
            CompetitorKeywords = new Dictionary<string, List<string>>();
            this.logger = logger;
        }

        public void Read()
        {
            if (string.IsNullOrWhiteSpace(_config.DataFolder))
            {
                logger.LogError("Set Config DataFolder");
                throw new Exception();
            }

            Apps = Directory.GetDirectories(_config.DataFolder).ToList();

            foreach (var app in Apps)
            {
                Keywords.Add(app, _keywordService.Read(app));
                Competitors.Add(app, _competitorService.Read(app));
                CompetitorKeywords.Add(app, _competitorKeywordsService.Read(app));
            }
        }

        public List<string> Apps { get; set; }
        public Dictionary<string, List<Keyword>> Keywords { get; set; }
        public Dictionary<string, List<Competitor>> Competitors { get; set; }
        public Dictionary<string, List<string>> CompetitorKeywords { get; set; }
    }
}