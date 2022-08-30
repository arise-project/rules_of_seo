using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class App : Page
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string SubTitleRu { get; set; }
        public Block Format { get; set; }
        public Block About { get; set; }
    }
}
