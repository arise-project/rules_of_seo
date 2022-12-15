using System.Collections.Generic;
using rules_of_seo.Model;

namespace rules_of_seo.Service
{
    public interface IKeywordService
    {
        List<Keyword> Read(string app);
    }
}