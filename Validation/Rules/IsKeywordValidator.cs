using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class IsKeywordValidator : IIsKeywordValidator
    {
        private readonly AppConfig _config;
        private readonly ISeoRepository _seoRepository;
        private readonly ILogger<IsKeywordValidator> logger;

        public IsKeywordValidator(
            ISeoRepository seoRepository,
            IOptions<AppConfig> config,
            ILogger<IsKeywordValidator> logger)
        {
            _config = config.Value;
            _seoRepository = seoRepository;
            this.logger = logger;
        }

        public string Slug { get; } = "is-keyword";

        // check all text is keyword
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if (r.IsKeyword != true)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(c.Value))
            {
                return new RuleMessage
                {
                    MessageLevel = MessageLevel.Error,
                    Message = $"No keyword found at empty chunk"
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
                        MessageLevel = MessageLevel.Info,
                        Message = "Text is keyword :" + c.Value
                    };
                }

                if (c.Value.IndexOf(k.Key, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    return new RuleMessage
                    {
                        MessageLevel = MessageLevel.Error,
                        Message = "Sould be keyword " + k + "in " + c.Value
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
