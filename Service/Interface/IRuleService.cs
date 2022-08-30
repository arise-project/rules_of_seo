using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Service.Inerface
{
    public interface IRuleService
    {
        Dictionary<string, Rule> GetRules(string settingsFile);
    }
}
