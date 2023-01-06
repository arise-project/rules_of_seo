using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;
using Microsoft.Extensions.Options;
using rules_of_seo.Service.Interfaces;
using System;

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
            
            var keywords = _seoRepository.Keywords[_config.App];
            foreach(var k in keywords)
            {
            	if(string.Equals(k.Key, c.Value, StringComparison.OrdinalIgnoreCase))
            	{
            		return new RuleMessage
		            {
		                MessageLevel = MessageLevel.Warning,
		                Message = $"Should be text before keyword " + k + "in " + c.Value
		            };
            	};
            	
            	if(c.Value.EndsWith(k.Key))
            	{
            		return new RuleMessage
		            {
		                MessageLevel = MessageLevel.Info,
		                Message = $"Foung text before keyword " + k + "in " + c.Value
		            };
            	};	
            }
            
            return new RuleMessage
		            {
		                MessageLevel = MessageLevel.Error,
		                Message = $"No keyword found at end of " + c.Value
		            };
        }
    }
}
