using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MiddleKeywordValidator : IMiddleKeywordValidator
    {
        private readonly ISeoRepository _seoRepository;
        public MiddleKeywordValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "middle-keyword";

		// ?
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.MiddleKeyword != true)
            {
                return null;
            }
            
            return null;
        }
    }
}
