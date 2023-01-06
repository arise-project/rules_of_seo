using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class FormatBlock
    {
        [Slug("app-format-title")]
        public string? Title { get; set; }

        [Slug("app-format-description-ru")]
        public string? DescriptionRu { get; set; }
        
        [Slug("app-format-description")]
        public string? Description { get; set; }
    }
}
