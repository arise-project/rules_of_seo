using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class IsKeywordValidator : IIsKeywordValidator
    {
        private readonly ISeoRepository _seoRepository;
        public IsKeywordValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug {get; } = "is-keyword";

		// check all text is keyword
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.IsKeyword != true)
            {
                return null;
            }

            return null;
        }
    }
}
