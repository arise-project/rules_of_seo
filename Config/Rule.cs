namespace rules_of_seo.Config
{
    public class Rule
    {
        public string Slug { get; set; }

        public int MinKeywords { get; set; }

        public int MaxKeywords { get; set; }

        public int MinLength { get; set; }

        public int? MaxMax { get; set; }

        public int? MaxCompetitorLength { get; set; }

        public bool AllowAdditionParagraph { get; set; }

        public bool Unique { get; set; }

        public bool CompetitorsMix { get; set; }

        public bool CheckPlagiat { get; set; }

        public bool IsKeyword { get; set; }

        public bool IsUrl { get; set; }

        public bool FirstIncludeOthers { get; set; }

        public bool StartKeyword { get; set; }

        public bool EndKeyword { get; set; }

        public string Ref { get; set; }
        
        public bool MiddleKeyword { get; set; }
    }
}