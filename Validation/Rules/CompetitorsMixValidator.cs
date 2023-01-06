using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;
using rules_of_seo.Service.Interfaces;
using Microsoft.Extensions.Options;

namespace rules_of_seo.Validation.Rules
{
    public class CompetitorsMixValidator : ICompetitorsMixValidator
    {
   		private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        
        public CompetitorsMixValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "competitors-mix";
	
		// check is any sentences of competitors exists. Better to copy more from competitors.
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if(r.CompetitorsMix != true)
            {
                return null;
            }

            return null;
        }
    }
}
