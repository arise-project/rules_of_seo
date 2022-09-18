using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace rules_of_seo.Config
{
    public class Settings
    {
        public List<Rule> Rules { get; set; }
        
        [YamlMember(Alias = "rule-keys", ApplyNamingConventions = false)]
        public List<string> RuleKeys { get; set; }

        [YamlMember(Alias = "keywords-file", ApplyNamingConventions = false)]
        public string KeywordsFile { get; set; }

        [YamlMember(Alias = "competitor-keywords-file", ApplyNamingConventions = false)]
        public string CompetitorKeywordsFile { get; set; }

        [YamlMember(Alias = "competitor-file", ApplyNamingConventions = false)]
        public string CompetitorFile { get; set; }
    }
}
