using System.Collections.Generic;
using System.Linq;
using rules_of_seo.Config;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class RuleService : IRuleService
    {
        private readonly Settings settings;

        public RuleService(Settings settings)
        {
            this.settings = settings;
        }

        public Dictionary<string, Rule> GetRules()
        {
            return settings.Rules.ToDictionary(s => s.Slug, s => s);
        }
    }
}
