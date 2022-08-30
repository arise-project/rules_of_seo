using rules_of_seo;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(Startup.Services)
    .Build();

await host.RunAsync();
