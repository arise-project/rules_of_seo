using YamlDotNet.Serialization;

namespace rules_of_seo.Config
{
    public class Rule
    {
        public string? Slug { get; set; }

        [YamlMember(Alias = "min-keywords", ApplyNamingConventions = false)]
        public int? MinKeywords { get; set; }

        [YamlMember(Alias = "max-keywords", ApplyNamingConventions = false)]
        public int? MaxKeywords { get; set; }

        [YamlMember(Alias = "min-length", ApplyNamingConventions = false)]
        public int? MinLength { get; set; }

        [YamlMember(Alias = "max-length", ApplyNamingConventions = false)]
        public int? MaxLength { get; set; }

        [YamlMember(Alias = "max-competitor-length", ApplyNamingConventions = false)]
        public bool? MaxCompetitorLength { get; set; }

        [YamlMember(Alias = "allow-addition-paragraph", ApplyNamingConventions = false)]
        public bool? AllowAdditionParagraph { get; set; }

        public bool? Unique { get; set; }

        [YamlMember(Alias = "competitors-mix", ApplyNamingConventions = false)]
        public bool? CompetitorsMix { get; set; }

        [YamlMember(Alias = "check-plagiat", ApplyNamingConventions = false)]
        public bool? CheckPlagiat { get; set; }

        [YamlMember(Alias = "is-keyword", ApplyNamingConventions = false)]
        public bool? IsKeyword { get; set; }

        [YamlMember(Alias = "is-url", ApplyNamingConventions = false)]
        public bool? IsUrl { get; set; }

        [YamlMember(Alias = "first-include-others", ApplyNamingConventions = false)]
        public bool? FirstIncludeOthers { get; set; }

        [YamlMember(Alias = "start-keyword", ApplyNamingConventions = false)]
        public bool? StartKeyword { get; set; }

        [YamlMember(Alias = "end-keyword", ApplyNamingConventions = false)]
        public bool? EndKeyword { get; set; }

        [YamlMember(Alias = "ref", ApplyNamingConventions = false)]
        public string? Ref { get; set; }
        
        [YamlMember(Alias = "middle-keyword", ApplyNamingConventions = false)]
        public bool? MiddleKeyword { get; set; }
        
        [YamlMember(Alias = "is-unique", ApplyNamingConventions = false)]
        public bool? IsUnique { get; set; }
    }
}