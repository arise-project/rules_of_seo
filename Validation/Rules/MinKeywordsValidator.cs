using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MinKeywordsValidator : IMinKeywordsValidator
    {
        private readonly ISeoRepository _seoRepository;
        public MinKeywordsValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "min-keywords"; 

		// ceck min count of keywords appeared
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(!r.MinKeywords.HasValue)
            {
                return null;
            }

            return null;
        }
    }
}
