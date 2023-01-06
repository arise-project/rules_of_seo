using System.Collections.Generic;
using rules_of_seo.Model;

namespace rules_of_seo.Service
{
    public interface ICompetitorService
    {
        List<Competitor> Read(string app);
    }
}