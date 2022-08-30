using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Config
{
    [AttributeUsage(System.AttributeTargets.Property)]
    public class SlugAttribute : System.Attribute
    {
        public string Slug { get; set; }
        public double Version { get; set; }

        public SlugAttribute(string slug)
        {
            Slug = slug;
            Version = 1.0;
        }
    }
}
