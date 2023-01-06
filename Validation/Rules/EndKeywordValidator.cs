using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;
using Microsoft.Extensions.Options;
using rules_of_seo.Service.Interfaces;

namespace rules_of_seo.Validation.Rules
{
    public class EndKeywordValidator : IEndKeywordValidator
    {
        private readonly ISeoRepository _seoRepository;
        private readonly ILogger<EndKeywordValidator> logger;
        private readonly AppConfig _config;

        public EndKeywordValidator(
            ISeoRepository seoRepository,
            IOptions<AppConfig> config,
            ILogger<EndKeywordValidator> logger)
        {
            _config = config.Value;
            _seoRepository = seoRepository;
            this.logger = logger;
        }

        public string Slug { get; } = "end-keyword";

        // text ends with keyword
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if (r.EndKeyword != true)
            {
                return null;
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

                if (c.Value?.EndsWith(k.Key) == true)
                {
                    return new RuleMessage
                    {
                        MessageLevel = MessageLevel.Info,
                        Message = "Foung text before keyword " + k + "in " + c.Value
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
