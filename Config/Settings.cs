using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Config
{
    public class Settings
    {
        public List<Rule> Rules { get; set; }
        public string KeywordsFile { get; set; }
        public string CompetitorKeywordsFile { get; set; }
        public string PageFile { get; set; }
        public List<string> CompetitorFiles { get; set; }
    }
}
