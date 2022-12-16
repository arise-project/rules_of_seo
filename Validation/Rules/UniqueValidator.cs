using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class UniqueValidator : IUniqueValidator
    {
        private readonly ISeoRepository _seoRepository;
        
        public UniqueValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "is-unique";

		// walidate within apps overview is texts complitly different by sentences 
		// or long sequence algorithms
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.Unique != true)
            {
                return null;
            }

            return null;
        }
    }
}
