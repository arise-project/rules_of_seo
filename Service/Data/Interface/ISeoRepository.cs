using rules_of_seo.Model;

namespace rules_of_seo.Service.Interfaces
{
    public interface ISeoRepository
    {
        void Read();
        List<string> Apps { get; }
        Dictionary<string, List<Keyword>> Keywords { get; set; }
        Dictionary<string, List<Competitor>> Competitors { get; set; }
        Dictionary<string, List<string>> CompetitorKeywords { get; set; }
    }
}