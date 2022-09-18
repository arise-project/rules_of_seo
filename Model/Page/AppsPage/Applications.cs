using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class Applications
    {
        [Slug("applications-segment")]
        public string Segment { get; set; }
        
        public AppBlock App { get; set; }
    }
}
