using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class Format : Page
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string SubTitleRu { get; set; }
        public string Button { get; set; }
        public Block About { get; set; }
        public Block HowTo { get; set; }
    }
}
