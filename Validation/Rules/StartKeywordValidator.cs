using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class StartKeywordValidator : IStartKeywordValidator
    {
		private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        
        public StartKeywordValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "start-keyword";

		// check is text starts with any keyword
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.StartKeyword != true)
            {
                return null;
            }

            return null;
        }
    }
}
