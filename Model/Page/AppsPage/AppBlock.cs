using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class AppBlock
    {
        [Slug("applications-app-title")]
        public string? Title { get; set; }

        [Slug("applications-app-description-ru")]
        public string? DescriptionRu { get; set; }
        
        [Slug("applications-app-description")]
        public string? Description { get; set; }
    }
}
