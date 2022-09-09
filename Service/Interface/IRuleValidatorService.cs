using rules_of_seo.Config;
using rules_of_seo.Model;
namespace rules_of_seo.Service.Inerface
{
    public interface IRuleValidatorService
    {
        Dictionary<string, List<RuleMessage>> Validate(Dictionary<string, List<string>> content, Dictionary<string, Rule> rules);
    }
}
