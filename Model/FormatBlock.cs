using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class FormatBlock
    {
        [Slug("app-format-title")]
        public string Title { get; set; }
        [Slug("app-format-description-ru")]
        public string DescriptionRu { get; set; }
        [Slug("app-format-description")]
        public string Description { get; set; }
    }
}
