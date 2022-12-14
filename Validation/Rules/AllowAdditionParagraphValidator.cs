using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;
using rules_of_seo.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace rules_of_seo.Validation.Rules
{
    public class AllowAdditionParagraphValidator : IAllowAdditionParagraphValidator
    {
        private readonly ISeoRepository _seoRepository;
        private readonly ILogger<AllowAdditionParagraphValidator> logger;

        public AllowAdditionParagraphValidator(ISeoRepository seoRepository, ILogger<AllowAdditionParagraphValidator> logger)
        {
            _seoRepository = seoRepository;
            this.logger = logger;
        }

        public string RuleName { get; } = "allow-addition-paragraph";

        public const string ParagraphTagBeg = "<p>";
        public const string ParagraphTagEnd = "</p>";

        // check paragraphs valid in text or no paragraphs addtion paragraphs
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if (!r.AllowAdditionParagraph.HasValue)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(c.Value))
            {
                logger.LogError("Chunk is empty");
                return null;
            }

            bool allowAdditionParagraph = true;
            if (r.AllowAdditionParagraph != true)
            {
                allowAdditionParagraph = false;
            }

            int bc = 0, ec = 0, b = 0, e = 0;

            do
            {
                b = c.Value.IndexOf(ParagraphTagBeg, b, c.Value.Length - b, StringComparison.OrdinalIgnoreCase);
                if (b != -1)
                {
                    bc++;
                    b++;
                }
            }
            while (b != -1);

            do
            {
                e = c.Value.IndexOf(ParagraphTagBeg, e, c.Value.Length - e, StringComparison.OrdinalIgnoreCase);
                if (e != -1)
                {
                    ec++;
                    e++;
                }
            }
            while (b != -1);

            if (bc != ec)
            {
                return new RuleMessage
                {
                    MessageLevel = MessageLevel.Error,
                    Message = $"Not enclosed paragraph tags found"
                };
            }

            if (allowAdditionParagraph)
            {
                return new RuleMessage
                {
                    MessageLevel = MessageLevel.Info,
                    Message = $"found {bc} paragraphs"
                };
            }
            else if (bc > 1)
            {
                return new RuleMessage
                {
                    MessageLevel = MessageLevel.Error,
                    Message = $"found additomal paragraphs {bc} paragraphs"
                };
            }

            return null;
        }
    }
}
