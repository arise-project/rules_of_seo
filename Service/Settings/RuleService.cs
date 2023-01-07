using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using rules_of_seo.Config;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class RuleService : IRuleService
    {
        private readonly Settings settings;
        private readonly ILogger<RuleService> logger;

        public RuleService(Settings settings, ILogger<RuleService> logger)
        {
            this.settings = settings;
            this.logger = logger;
        }

        public Dictionary<string, Rule> GetRules()
        {
            var rules = settings.Rules.ToDictionary(s => s.Slug, s => s);
            logger.LogInformation($"Rules: {string.Join(Environment.NewLine, rules.Select(r => r.Key))}");
            return rules;
        }
    }
}
