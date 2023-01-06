using Microsoft.Extensions.Hosting;
using rules_of_seo;
using System.Threading.Tasks;

public static class Program
{
    public static async Task Main(string [] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(Startup.Configuration)
            .ConfigureServices(Startup.Services)
            .Build();

        await host.RunAsync();
    }
}

