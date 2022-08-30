using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using rules_of_seo.Validation;
using rules_of_seo.Service.Inerface;

namespace rules_of_seo.Service
{
    public class SlugService : ISlugService
    {
        public List<IValidator> Assign(object root, string slug, List<IValidator> validators)
        {
            var children = root.GetType().GetProperties()
                .Select(p => p.GetCustomAttributes(typeof(SlugAttribute), false).First());

            return null;
        }
    }
}
