using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class RefValidator : IRefValidator
    {
        public RefValidator()
        {

        }

        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(string.IsNullOrWhiteSpace(r.Ref))
            {
                return null;
            }

            return null;
        }
    }
}
