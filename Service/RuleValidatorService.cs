using rules_of_seo.Config;
using rules_of_seo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Service
{
    public class RuleValidatorService : IRuleValidatorService
    {
        public Dictionary<string, List<RuleMessage>> Validate(Dictionary<string, List<string>> content, Dictionary<string, Rule> rules)
        {
            return null;
        }
    }
}
