using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class Format
    {
        [Slug("format-segment")]
        public string Segment { get; set; }
        [Slug("format-title")]
        public string Title { get; set; }
        [Slug("format-sub-title")]
        public string SubTitle { get; set; }
        [Slug("format-sub-title-ru")]
        public string SubTitleRu { get; set; }
        public string Button { get; set; }
        public FormatAboutBlock About { get; set; }
        public FormatHowToBlock HowTo { get; set; }
    }
}
