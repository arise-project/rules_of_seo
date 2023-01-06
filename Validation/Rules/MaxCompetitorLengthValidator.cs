using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class MaxCompetitorLengthValidator : IMaxCompetitorLengthValidator
    {
        private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        private readonly ILogger<MaxCompetitorLengthValidator> logger;

        public MaxCompetitorLengthValidator(
            ISeoRepository seoRepository,
            IOptions<AppConfig> config,
            ILogger<MaxCompetitorLengthValidator> logger)
        {
            _config = config.Value;
            _seoRepository = seoRepository;
            this.logger = logger;
        }

        public string Slug { get; } = "max-competitor-length";

        // win competitors by length
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if (r.MaxCompetitorLength != true)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(c.Value))
            {
                return new RuleMessage
                {
                    MessageLevel = MessageLevel.Error,
                    Message = $"Chunk is empty but competitors"
                };
            }

            if (string.IsNullOrWhiteSpace(_config.App))
            {
                logger.LogError("Set Config App");
                throw new Exception();
            }

            var competitors = _seoRepository.Competitors[_config.App];

            int m = 0;
            foreach (var comp in competitors)
            {
                if (comp == null)
                {
                    logger.LogError("competitor is null");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(comp.Description))
                {
                    logger.LogError("competitor have no description");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(comp.Description) && m < comp.Description.Length)
                {
                    m = comp.Description.Length;
                }
            }

            if (m > c.Value.Length)
            {
                new RuleMessage
                {
                    MessageLevel = MessageLevel.Error,
                    Message = $"Found competitor with larger text when " + c.Value
                };
            }

            return new RuleMessage
            {
                MessageLevel = MessageLevel.Info,
                Message = $"Win competitors by length " + c.Slug
            };
        }
    }
}
