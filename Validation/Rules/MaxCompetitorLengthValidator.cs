using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MaxCompetitorLengthValidator : IMaxCompetitorLengthValidator
    {
		private readonly AppConfig _config;    	
        private readonly ISeoRepository _seoRepository;
        
        public MaxCompetitorLengthValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "max-competitor-length";

		// win competitors by length
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.MaxCompetitorLength != true)
            {
                return null;
            }

            return null;
        }
    }
}
