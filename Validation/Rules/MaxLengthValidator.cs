using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MaxLengthValidator : IMaxLengthValidator
    {
        private readonly ISeoRepository _seoRepository;
        
        public MaxLengthValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "max-length";

		// check max length is not exid
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if(!r.MaxLength.HasValue)
            {
                return null;
            }
            
            return null;
        }
    }
}
