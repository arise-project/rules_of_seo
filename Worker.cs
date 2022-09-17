using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using rules_of_seo.Service.Inerface;

namespace rules_of_seo
{
    public class Worker : BackgroundService
    {
        private readonly IValidationUnit  _validation;
        private readonly ILogger<Worker> _logger;

        public Worker(
            IValidationUnit validation,
            ILogger<Worker> logger)
        {
            _validation = validation;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            await Task.Run(
                () => _validation.Execute(), 
                stoppingToken);
        }
    }
}

