using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Service
{
    public class SlugService
    {
        public void Assign(object root, Dictionary<string, Validator> validators)
        {
            var children = root.GetType().GetProperties()
                .Select(p => p.GetCustomAttributes(typeof(SlugAttribute), false).First());

            var children = root.GetType().GetProperties()
                .Select(p => p.GetCustomAttributes(typeof(SlugAttribute), false).First());
        }
    }
}
