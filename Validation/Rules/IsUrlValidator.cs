using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class IsUrlValidator : IIsUrlValidator
    {
        private readonly ISeoRepository _seoRepository;
        
        public IsUrlValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "is-url";

		// is this required? because this for segmet keyword read
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.IsUrl != true)
            {
                return null;
            }
            

            return null;
        }
    }
}
