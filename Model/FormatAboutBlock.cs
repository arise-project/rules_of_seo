using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class FormatAboutBlock
    {
        [Slug("format-about-title")]
        public string Title { get; set; }
        [Slug("format-about-description-ru")]
        public string DescriptionRu { get; set; }
        [Slug("format-about-description")]
        public string Description { get; set; }
    }
}
