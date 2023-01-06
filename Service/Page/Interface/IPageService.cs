using rules_of_seo.Model;
using System.Collections.Generic;

namespace rules_of_seo.Service.Interface
{
    public interface IPageService
    {
        List<PageChunk> Read(string fileName);
    }
}
