using rules_of_seo.Model;

namespace rules_of_seo.Service.Interface
{
    public interface IHierarchyWalker
    {
        void Open(string textFile);
        public PageChunk? Read();
        void Close();
    }
}
