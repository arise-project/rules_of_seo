using rules_of_seo.Validation.Interfaces;

namespace rules_of_seo.Service.Interface
{
    public interface ISlugService
    {
        List<IValidator> Assign(object root, string slug, List<IValidator> validators);
    }
}
