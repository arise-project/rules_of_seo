using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MaxLengthValidator : IMaxLengthValidator
    {
        public MaxLengthValidator()
        {

        }

        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(!r.MaxLength.HasValue)
            {
                return null;
            }
            
            return null;
        }
    }
}
