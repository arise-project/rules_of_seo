using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using rules_of_seo.Service.Interfaces;

namespace rules_of_seo.Service
{
    public class SeoRepository : ISeoRepository
    {
        private readonly AppConfig _config;
        private readonly IKeywordService _keywordService;
        private readonly ICompetitorService _competitorService;
        private readonly ICompetitorKeywordsService _competitorKeywordsService;

        public SeoRepository(
            IOptions<AppConfig> config,
            IKeywordService keywordService,
            ICompetitorService competitorService,
           	ICompetitorKeywordsService competitorKeywordsService)
        {
            _config = config.Value;
            _keywordService = keywordService;
			_competitorService = competitorService;
			_competitorKeywordsService = competitorKeywordsService;
            
            Keywords = new Dictionary<string, List<Keyword>>();
            Competitors = new Dictionary<string, List<Competitor>>();
            CompetitorKeywords = new Dictionary<string, List<string>>(); 
        }
        
        public void Read()
        {
            Apps = Directory.GetDirectories(_config.DataFolder).ToList();
            foreach(var app in Apps)
            {
            	Keywords.Add(app, _keywordService.Read(app));
            	Competitors.Add(app, _competitorService.Read(app));
            	CompetitorKeywords.Add(app, _competitorKeywordsService.Read(app));
            }
        }
        
        public List<string> Apps { get; }
        public Dictionary<string, List<Keyword>> Keywords { get; }
        public Dictionary<string, List<Competitor>> Competitors { get; }
        public Dictionary<string, List<string>> CompetitorKeywords { get; }
    }
}