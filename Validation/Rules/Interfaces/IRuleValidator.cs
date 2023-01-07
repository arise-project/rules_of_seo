using rules_of_seo.Config;
using rules_of_seo.Model;

namespace rules_of_seo.Validation.Rules.Interface
{
    public interface IRuleValidator
    {
        public string RuleName { get; }
        RuleMessage? Validate(PageChunk c, Rule r);
    }
}
