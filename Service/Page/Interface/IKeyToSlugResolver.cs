using rules_of_seo.Model;
using rules_of_seo.Service.Inerface;

namespace rules_of_seo.Service.Inerface
{
    public interface IKeyToSlugResolver
    {
        public string Resolve(string key);
    }
}
