using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Service
{
    public interface IPageService
    {
        public Dictionary<string, List<string>> GetSegments(string fileName);
    }
}
