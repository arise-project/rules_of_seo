using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class IsKeywordValidator : IIsKeywordValidator
    {
    	private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        
        public IsKeywordValidator(
        	ISeoRepository seoRepository,
        	IOptions<AppConfig> config)
        {
        	_config = config.Value;
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "is-keyword";

		// check all text is keyword
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.IsKeyword != true)
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
		                MessageLevel = MessageLevel.Info,
		                Message = $"Text is keyword :" + c.Value
		            };
            	};
            	
            	if(c.Value.IndexOf(k, StringComparison.OrdinalgnoreCase) != -1))
            	{
            		return new RuleMessage
		            {
		                MessageLeveln = MessageLevel.Error,
		                Message = $"Sould be keyword " + k + "in " + c.Value
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
