using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MinLengthValidator : IMinLengthValidator
    {
        private readonly ISeoRepository _seoRepository;
        
        public MinLengthValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "min-length";

		// check min lengh
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if(!r.MinLength.HasValue)
            {
                return null;
            }
            
            return null;
        }
    }
}
