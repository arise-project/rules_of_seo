namespace rules_of_seo.Service.Interfaces
{
    public interface ISeoRepository
    {
        void Read();
        List<string> Apps { get; }
        Dictionary<string, List<Keyword>> Keywords { get; }
        Dictionary<string, List<Competitor>> Competitors { get; }
        Dictionary<string, List<string>> CompetitorKeywords { get; }
    }
}