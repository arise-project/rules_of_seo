using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class Format
    {
        [Slug("format-segment")]
        public string? Segment { get; set; }
        
        [Slug("format-title")]
        public string? Title { get; set; }
        
        [Slug("format-sub-title")]
        public string? SubTitle { get; set; }
        
        [Slug("format-sub-title-ru")]
        public string? SubTitleRu { get; set; }
        
        public string? Button { get; set; }
        
        public FormatAboutBlock? About { get; set; }
        
        public FormatHowToBlock? HowTo { get; set; }
    }
}
