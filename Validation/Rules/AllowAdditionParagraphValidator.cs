using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Interface;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class AllowAdditionParagraphValidator : IAllowAdditionParagraphValidator
    {
        public AllowAdditionParagraphValidator()
        {

        }

        public RuleMessage Validate(PageChunk c, Rule r)
        {
            return null;
        }
    }
}