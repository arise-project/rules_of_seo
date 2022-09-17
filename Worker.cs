using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Service.Inerface;

namespace rules_of_seo
{
    public class Worker : BackgroundService
    {
        private readonly AppConfiguration _config;
        private readonly IValidationUnit  _validation;
        private readonly ILogger<Worker> _logger;

        public Worker(
            IOptions<AppConfiguration> config,
            IValidationUnit validation,
            ILogger<Worker> logger)
        {
            _config = config.Value;
            _validation = validation;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            _logger.LogInformation("App: Config:"+ JsonSerializer.Serialize(_config));
            await Task.Run(
                () => _validation.Execute(), 
                stoppingToken);
        }
    }
}

