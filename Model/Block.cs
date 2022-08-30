using rules_of_seo.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Model
{
    public class Block
    {
        [Slug("title")]
        public string Title { get; set; }
        [Slug("description-ru")]
        public string DescriptionRu { get; set; }
        [Slug("description")]
        public string Description { get; set; }
    }
}
