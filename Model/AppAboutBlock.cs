using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class AppAboutBlock
    {
        [Slug("app-about-title")]
        public string Title { get; set; }
        [Slug("app-about-description-ru")]
        public string DescriptionRu { get; set; }
        [Slug("app-about-description")]
        public string Description { get; set; }
    }
}
