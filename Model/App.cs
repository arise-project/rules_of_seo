using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class App
    {
        [Slug("app-segment")]
        public string Segment { get; set; }
        [Slug("app-title")]
        public string Title { get; set; }
        [Slug("app-sub-title")]
        public string SubTitle { get; set; }
        [Slug("app-sub-title-ru")]
        public string SubTitleRu { get; set; }
        public FormatBlock Format { get; set; }
        public AppAboutBlock About { get; set; }
    }
}
