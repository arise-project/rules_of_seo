using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using rules_of_seo.Validation;

namespace rules_of_seo.Service.Inerface
{
    public interface ISlugService
    {
        List<IValidator> Assign(object root, string slug, List<IValidator> validators);
    }
}
