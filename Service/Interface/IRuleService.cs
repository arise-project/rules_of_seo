using rules_of_seo.Config;
namespace rules_of_seo.Service.Inerface
{
    public interface IRuleService
    {
        Dictionary<string, Rule> GetRules(string settingsFile);
    }
}
