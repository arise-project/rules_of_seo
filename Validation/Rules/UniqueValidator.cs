using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;
using rules_of_seo.Service.Interfaces;
using Microsoft.Extensions.Options;

namespace rules_of_seo.Validation.Rules
{
    public class UniqueValidator : IUniqueValidator
    {
    	private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        
        public UniqueValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string RuleName { get; } = "is-unique";

		// same with plagiat? walidate within apps overview is texts complitly different by sentences 
		// or long sequence algorithms
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if(r.Unique != true)
            {
                return null;
            }

            return null;
        }
    }
}
