using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MaxKeywordsValidator : IMaxKeywordsValidator
    {
        private readonly ISeoRepository _seoRepository;
        public MaxKeywordsValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug {get; } = "max-keywords";

		// do not use a lot of keywords
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(!r.MaxKeywords.HasValue)
            {
                return null;
            }

            return null;
        }
    }
}
