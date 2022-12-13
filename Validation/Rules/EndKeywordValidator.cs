using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class EndKeywordValidator : IEndKeywordValidator
    {
        public EndKeywordValidator()
        {

        }

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
