using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    [Slug("applications")]
    public class Applications : Page
    {
        [Slug("app")]
        public Block App { get; set; }
    }
}
