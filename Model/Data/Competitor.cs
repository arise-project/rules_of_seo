using System.Collections.Generic;

namespace rules_of_seo.Model
{
    public class Competitor
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public List<string>? Keywords { get; set; }
        public string? Description { get; set; }
    }
}