using System.Collections.Generic;
using rules_of_seo.Model;

namespace rules_of_seo.Service.Interface
{
    public interface IPageService
    {
        List<PageChunk> Read(string fileName);
    }
}
