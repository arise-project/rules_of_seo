using rules_of_seo.Service.Inerface;

namespace rules_of_seo;

public class Worker : BackgroundService
{
    private readonly IValidationScenarioService validationScenarioService;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IValidationScenarioService validationScenarioService,
        ILogger<Worker> logger)
    {
        this.validationScenarioService = validationScenarioService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Run(() => validationScenarioService.Execute());
    }
}
