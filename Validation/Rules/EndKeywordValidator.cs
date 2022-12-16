using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class EndKeywordValidator : IEndKeywordValidator
    {
        private readonly ISeoRepository _seoRepository;
        private readonly AppConfig _config;
        
        public EndKeywordValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "end-keyword";

		// text ends with keyword
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.EndKeyword != true)
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
            	
            	if(c.Value.EndWith(k)))
            	{
            		return new RuleMessage
		            {
		                MessageLeveln = MessageLevel.Info,
		                Message = $"Foung text before keyword " + k + "in " + c.Value
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
