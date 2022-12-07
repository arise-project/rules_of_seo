using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Interfaces;

namespace rules_of_seo.Validation
{
    public class Validator : IValidator
    {
        public Validator()
        {

        }

        public List<RuleMessage> Validate(PageChunk c, Rule r)
        {
            return null;
        }
    }
}
