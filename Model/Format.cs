using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    [Slug("format")]
    public class Format : Page
    {
        [Slug("title")]
        public string Title { get; set; }
        [Slug("sub-title")]
        public string SubTitle { get; set; }
        [Slug("sub-title-ru")]
        public string SubTitleRu { get; set; }
        [Slug("button")]
        public string Button { get; set; }
        [Slug("about")]
        public Block About { get; set; }
        [Slug("how-to")]
        public Block HowTo { get; set; }
    }
}
