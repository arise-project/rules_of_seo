using System.Collections.Generic;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class PageService : IPageService
    {
        private readonly IHierarchyWalker hierarchyWalker;

        public PageService(IHierarchyWalker hierarchyWalker)
        {
            this.hierarchyWalker = hierarchyWalker;
        }

        public List<PageChunk> Read(string fileName)
        {
            var texts = new List<PageChunk>();
            PageChunk? c;

            do
            {
                hierarchyWalker.Open(fileName);
                c = hierarchyWalker.Read();
                if(!string.IsNullOrEmpty(c?.Slug))
                {
                    texts.Add(c);
                }
            }
            while(c != null);

            return texts;
        }
    }
}
