using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class AppAboutBlock
    {
        [Slug("app-about-title")]
        public string Title { get; set; }
        [Slug("app-about-description-ru")]
        public string DescriptionRu { get; set; }
        [Slug("app-about-description")]
        public string Description { get; set; }
    }
}
