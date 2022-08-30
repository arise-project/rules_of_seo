using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rules_of_seo
{
    public static class Startup
    {
        public static void Services(IServiceCollection services)
        {
            services.AddHostedService<Worker>();
        }
    }
}
