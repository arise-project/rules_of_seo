using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Inerface;
namespace rules_of_seo.Service
{
    public class ValidationUnit : IValidationUnit
    {
        private readonly AppConfig _config;
        private readonly IRuleService _ruleService;
        private readonly IPageService _pageService;

        public ValidationUnit(
            IOptions<AppConfig> config,
            IRuleService ruleService, 
            IPageService pageService
            )
        {
            _config = config.Value;
            _ruleService = ruleService;
            _pageService = pageService;
        }
        
        public void Execute()
        {
            var rules = _ruleService.GetRules(_config.SettingsFile);
            var pages = new List<PageFile>();
            foreach (var textFile in Directory.GetFiles(
                _config.TextFolder, 
                "*.json", 
                SearchOption.TopDirectoryOnly))
            {
                pages.Add(
                    new PageFile(textFile)
                    {
                        Chunks = _pageService.Read(textFile) 
                    });
            }
            
            foreach(var page in pages)
            {
            		
            }
        }
    }
}
