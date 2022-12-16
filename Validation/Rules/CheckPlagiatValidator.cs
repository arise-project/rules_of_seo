using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class CheckPlagiatValidator : ICheckPlagiatValidator
    {
    	private readonly ISeoRepository _seoRepository;
        public CheckPlagiatValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug { get; } = "check-plagiat";

		// is this possible to check?
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.CheckPlagiat != true)
            {
                return null;
            }

            return null;
        }
    }
}
