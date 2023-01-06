using System.Collections.Generic;
using rules_of_seo.Config;

namespace rules_of_seo.Service.Interface
{
    public interface IRuleService
    {
        Dictionary<string, Rule> GetRules();
    }
}
