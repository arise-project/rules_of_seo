using Microsoft.Extensions.DependencyInjection;

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
