using rules_of_seo.Model;

namespace rules_of_seo.Service.Inerface
{
    public interface IPageService
    {
        List<PageChunk> Read(string fileName);
    }
}
