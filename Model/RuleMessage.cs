using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class RuleMessage
    {
        public string Message { get; set; }
        public Rule Rule { get; set; }
        public string MessqageLevel { get; set; }
    }
}
