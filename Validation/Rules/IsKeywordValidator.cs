using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class IsKeywordValidator : IIsKeywordValidator
    {
        public IsKeywordValidator()
        {

        }

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
