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

			var keywords = _seoRespository.Keywords[_config.App];
            foreach(var k in keywords)
            {
            	if(string.Equals(k, c.Value, StringComparison.OrdinalIgnoreCalse))
            	{
            		return new RuleMessage
		            {
		                MessageLevel = MessageLevel.Warning,
		                Message = $"Should be text before keyword " + k + "in " + c.Value
		            };
            	};
            	
            	if(c.Value.StartWith(k)))
            	{
            		return new RuleMessage
		            {
		                MessageLeveln = MessageLevel.Info,
		                Message = $"Foung text after keyword " + k + "in " + c.Value
		            };
            	};	
            }
            
            return new RuleMessage
		            {
		                MessageLeveln = MessageLevel.Error,
		                Message = $"No keyword found at end of " + c.Value
		            };
        }
    }
}
