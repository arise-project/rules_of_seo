using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace rules_of_seo
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(Startup.Configuration)
                .ConfigureServices(Startup.Services)
                .Build();

            await host.RunAsync();
        }
    }
}