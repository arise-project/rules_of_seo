using rules_of_seo.Model;
using rules_of_seo.Service.Interface;
using System.Collections.Generic;

namespace rules_of_seo.Service
{
    public class PageService : IPageService
    {
        private readonly IKeyToSlugResolver slugResolver;
        private readonly IHierarchyWalker hierarchyWalker;

        public PageService(IKeyToSlugResolver slugResolver, IHierarchyWalker hierarchyWalker)
        {
            this.slugResolver = slugResolver;
            this.hierarchyWalker = hierarchyWalker;
        }

        public List<PageChunk> Read(string fileName)
        {
            var texts = new List<PageChunk>();
            PageChunk? c;

            do
            {
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
