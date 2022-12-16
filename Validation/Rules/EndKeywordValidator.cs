using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class EndKeywordValidator : IEndKeywordValidator
    {
        private readonly ISeoRepository _seoRepository;
        public EndKeywordValidator(ISeoRepository seoRepository)
        {
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

            return null;
        }
    }
}
