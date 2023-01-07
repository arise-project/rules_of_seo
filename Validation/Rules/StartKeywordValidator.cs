using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;
using rules_of_seo.Service.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;

namespace rules_of_seo.Validation.Rules
{
    public class StartKeywordValidator : IStartKeywordValidator
    {
        private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        private readonly ILogger<StartKeywordValidator> logger;

        public StartKeywordValidator(
            ISeoRepository seoRepository,
            IOptions<AppConfig> config,
            ILogger<StartKeywordValidator> logger)
        {
            _config = config.Value;
            _seoRepository = seoRepository;
            this.logger = logger;
        }

        public string RuleName { get; } = "start-keyword";

        // check is text starts with any keyword
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if (r.StartKeyword != true)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(c.Value))
            {
                return new RuleMessage
                {
                    MessageLevel = MessageLevel.Error,
                    Message = $"No keyword found at end of empty chunk"
                };
            }

            if (string.IsNullOrWhiteSpace(_config.App))
            {
                logger.LogError("Set Config App");
                throw new Exception();
            }

            var keywords = _seoRepository.Keywords[_config.App];
            foreach (var k in keywords)
            {
                if (k == null)
                {
                    logger.LogError("keyword is null");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(k.Key))
                {
                    logger.LogError("keyword key is null");
                    continue;
                }

                if (string.Equals(k.Key, c.Value, StringComparison.OrdinalIgnoreCase))
                {
                    return new RuleMessage
                    {
                        MessageLevel = MessageLevel.Warning,
                        Message = "Should be text before keyword " + k + "in " + c.Value
                    };
                }

                if (c.Value.StartsWith(k.Key))
                {
                    return new RuleMessage
                    {
                        MessageLevel = MessageLevel.Info,
                        Message = "Foung text after keyword " + k + "in " + c.Value
                    };
                }
            }

            return new RuleMessage
            {
                MessageLevel = MessageLevel.Error,
                Message = "No keyword found at end of " + c.Value
            };
        }
    }
}
