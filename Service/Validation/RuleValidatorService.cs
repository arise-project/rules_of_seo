using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;
using rules_of_seo.Validation.Interfaces;

namespace rules_of_seo.Service
{
    public class RuleValidatorService : IRuleValidatorService
    {
        private readonly IValidator validator;

        public RuleValidatorService(IValidator validator)
        {
            this.validator = validator;
        }

        public Dictionary<string, List<RuleMessage>> Validate(
            PageFile content,
            Dictionary<string, Rule> rules)
        {
            foreach(var c in content.Chunks)
            {
                if(rules.ContainsKey(c.Slug))
                {
                    var messages = validator.Validate(c, rules[c.Slug]);
                    foreach(var m in messages)
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("error: no rule for " + c.Slug);
                }
            }
            return null;
        }
    }
}
