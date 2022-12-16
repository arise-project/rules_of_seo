using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class CheckPlagiatValidator : ICheckPlagiatValidator
    {
    	private readonly AppConfig _config;
    	private readonly ISeoRepository _seoRepository;
    	
        public CheckPlagiatValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "check-plagiat";

		// this possible to check within available top competitors
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.CheckPlagiat != true)
            {
                return null;
            }

            return null;
        }
    }
}
