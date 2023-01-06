using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;
using rules_of_seo.Validation.Interfaces;

namespace rules_of_seo.Service
{
    public class ValidationUnit : IValidationUnit
    {
        private readonly AppConfig _config;
        private readonly IRuleService _ruleService;
        private readonly IPageService _pageService;
        private readonly IValidator _validator;
        
        public ValidationUnit(
            IOptions<AppConfig> config,
            IRuleService ruleService, 
            IPageService pageService,
            IValidator validator
            )
        {
            _config = config.Value;
            _ruleService = ruleService;
            _pageService = pageService;
            _validator = validator;
        }
        
        public void Execute()
        {
            var rules = _ruleService.GetRules(_config.SettingsFile);
            var pages = new List<PageFile>();
            foreach (var textFile in Directory.GetFiles(
                Path.Combine(_config.TextFolder, _config.App), 
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
            	var messages = _validator.Validate(page.Chunks, rules);
            	foreach(var m in message)
            	{
            		if(m == null)
            		{
            			Console.WriteLine("No iformation for page " + page.File);	
            		}
            		else
            		{
            			Console.WriteLine("Page " + page.File);
            			Console.WriteLine(m.ToString());
            		}
            	}
            }
        }
    }
}
