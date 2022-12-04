using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class FormatHowToBlock
    {
        [Slug("format-how-to-title")]
        public string Title { get; set; }

        [Slug("format-how-to-description-ru")]
        public string DescriptionRu { get; set; }
        
        [Slug("format-how-to-description")]
        public string Description { get; set; }
    }
}
