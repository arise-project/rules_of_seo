using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class FirstIncludeOthersValidator : IFirstIncludeOthersValidator
    {
        private readonly ISeoRepository _seoRepository;
        
        public FirstIncludeOthersValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "first-include-others";
        
		// is this reqired, this old data format
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.FirstIncludeOthers != true)
            {
                return null;
            }

            return null;
        }
    }
}
