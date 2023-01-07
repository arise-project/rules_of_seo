using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using rules_of_seo.Config;
using rules_of_seo.Service.Interface;
using System;

namespace rules_of_seo
{
    public class Worker : BackgroundService
    {
        private readonly AppConfig _config;
        private readonly IValidationUnit  _validation;
        private readonly ILogger<Worker> _logger;
        private readonly Settings _settings;
        private readonly IApplicationLifetime applicationLifetime;

        public Worker(
            IOptions<AppConfig> config,
            IValidationUnit validation,
            ILogger<Worker> logger,
            Settings settings,
            IApplicationLifetime applicationLifetime)
        {
            _config = config.Value;
            _validation = validation;
            _logger = logger;
            _settings = settings;
            this.applicationLifetime = applicationLifetime;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            await Task.Run(
                () =>
                {
                	try
                	{
                		_validation.Execute();
                        applicationLifetime.StopApplication();
                	}
                	catch(Exception ex)
                	{
                		_logger.LogError(ex, ex.Message);
                	}
                },
                stoppingToken);
        }
    }
}

