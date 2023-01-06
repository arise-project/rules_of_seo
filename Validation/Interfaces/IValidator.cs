using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;

namespace rules_of_seo.Validation.Interfaces
{
    public interface IValidator
    {
        List<RuleMessage> Validate(List<PageChunk> c, Dictionary<string, Rule> r);
    }
}
