using Microsoft.Extensions.Hosting;
using rules_of_seo;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(Startup.Configuration)
    .ConfigureServices(Startup.Services)
    .Build();

await host.RunAsync();
