using rules_of_seo.Model;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class PageService : IPageService
    {
        private readonly IKeyToSlugResolver slugResolver;

        public PageService(IKeyToSlugResolver slugResolver)
        {
            this.slugResolver = slugResolver;
        }

        public List<PageChunk> Read(string fileName)
        {
            var w = new HierarchyWalker(slugResolver);
            var texts = new List<PageChunk>();
            PageChunk c;

            do
            {
                c = w.Read();
                if(!string.IsNullOrEmpty(c.Slug))
                {
                    texts.Add(c);
                }
            }
            while(c != null);

            return texts;
        }
    }
}
