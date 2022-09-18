using System.Collections.Generic;
using rules_of_seo.Validation;
using rules_of_seo.Validation.Interface;

namespace rules_of_seo.Service.Inerface
{
    public interface ISlugService
    {
        List<IValidator> Assign(
            object root, 
            string slug, 
            List<IValidator> validators);
    }
}
