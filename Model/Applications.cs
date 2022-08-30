using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class Applications
    {
        [Slug("applications-segment")]
        public string Segment { get; set; }
        public AppBlock App { get; set; }
    }
}
