using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class FormatAboutBlock
    {
        [Slug("format-about-title")]
        public string Title { get; set; }

        [Slug("format-about-description-ru")]
        public string DescriptionRu { get; set; }
        
        [Slug("format-about-description")]
        public string Description { get; set; }
    }
}
