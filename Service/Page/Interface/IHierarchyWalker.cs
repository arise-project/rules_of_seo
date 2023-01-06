using rules_of_seo.Model;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service.Interface
{
    public interface IHierarchyWalker
    {
        void Open(string textFile);
        public PageChunk Read();
    }
}
