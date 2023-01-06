using YamlDotNet.Serialization;

namespace rules_of_seo.Model
{
    public class Keyword
    {
        [YamlMember(Alias = "keyword", ApplyNamingConventions = false)]
        public string? Key { get; set; }
        public string? Low { get; set; }
        public string? High { get; set; }
        
        public int LowValue { get; set; }
        public int HighValue { get; set; }
    }
}