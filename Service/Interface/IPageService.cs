using rules_of_seo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo.Service.Inerface
{
    public interface IPageService
    {
        Texts Read(string fileName);
    }
}
