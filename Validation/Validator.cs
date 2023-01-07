using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation
{
    public class Validator : IValidator
    {
        private readonly IAllowAdditionParagraphValidator _allowAdditionParagraphValidator;
        private readonly ICheckPlagiatValidator _checkPlagiatValidator;
        private readonly ICompetitorsMixValidator _competitorsMixValidator;
        private readonly IEndKeywordValidator _endKeywordValidator;
        private readonly IFirstIncludeOthersValidator _firstIncludeOthersValidator;
        private readonly IIsKeywordValidator _isKeywordValidator;
        private readonly IIsUrlValidator _isUrlValidator;
        private readonly IMaxCompetitorLengthValidator _maxCompetitorLengthValidator;
        private readonly IMaxKeywordsValidator _maxKeywordsValidator;
        private readonly IMaxLengthValidator _maxLengthValidator;
        private readonly IMiddleKeywordValidator _middleKeywordValidator;
        private readonly IMinKeywordsValidator _minKeywordsValidator;
        private readonly IMinLengthValidator _minLengthValidator;
        private readonly IRefValidator _refValidator;
        private readonly IStartKeywordValidator _startKeywordValidator;
        private readonly IUniqueValidator _uniqueValidator;
        private readonly ILogger<Validator> logger;
        private readonly Dictionary<string, IRuleValidator> _ruleValidators;

        public Validator(
        IAllowAdditionParagraphValidator allowAdditionParagraphValidator,
        ICheckPlagiatValidator checkPlagiatValidator,
        ICompetitorsMixValidator competitorsMixValidator,
        IEndKeywordValidator endKeywordValidator,
        IFirstIncludeOthersValidator firstIncludeOthersValidator,
        IIsKeywordValidator isKeywordValidator,
        IIsUrlValidator isUrlValidator,
        IMaxCompetitorLengthValidator maxCompetitorLengthValidator,
        IMaxKeywordsValidator maxKeywordsValidator,
        IMaxLengthValidator maxLengthValidator,
        IMiddleKeywordValidator middleKeywordValidator,
        IMinKeywordsValidator minKeywordsValidator,
        IMinLengthValidator minLengthValidator,
        IRefValidator refValidator,
        IStartKeywordValidator startKeywordValidator,
        IUniqueValidator uniqueValidator,
        ILogger<Validator> logger)
        {
            _allowAdditionParagraphValidator = allowAdditionParagraphValidator;
            _checkPlagiatValidator = checkPlagiatValidator;
            _competitorsMixValidator = competitorsMixValidator;
            _endKeywordValidator = endKeywordValidator;
            _firstIncludeOthersValidator = firstIncludeOthersValidator;
            _isKeywordValidator = isKeywordValidator;
            _isUrlValidator = isUrlValidator;
            _maxCompetitorLengthValidator = maxCompetitorLengthValidator;
            _maxKeywordsValidator = maxKeywordsValidator;
            _maxLengthValidator = maxLengthValidator;
            _middleKeywordValidator = middleKeywordValidator;
            _minKeywordsValidator = minKeywordsValidator;
            _minLengthValidator = minLengthValidator;
            _refValidator = refValidator;
            _startKeywordValidator = startKeywordValidator;
            _uniqueValidator = uniqueValidator;
            this.logger = logger;
            _ruleValidators = new Dictionary<string, IRuleValidator>
                            {
                                  { allowAdditionParagraphValidator.Slug, allowAdditionParagraphValidator },
                                  { checkPlagiatValidator.Slug, checkPlagiatValidator },
                                  { competitorsMixValidator.Slug, competitorsMixValidator },
                                  { endKeywordValidator.Slug, endKeywordValidator },
                                  { firstIncludeOthersValidator.Slug, firstIncludeOthersValidator },
                                  { isKeywordValidator.Slug, isKeywordValidator },
                                  { isUrlValidator.Slug, isUrlValidator },
                                  { maxCompetitorLengthValidator.Slug, maxCompetitorLengthValidator },
                                  { maxKeywordsValidator.Slug, maxKeywordsValidator },
                                  { maxLengthValidator.Slug, maxLengthValidator },
                                  { middleKeywordValidator.Slug, middleKeywordValidator },
                                  { minKeywordsValidator.Slug, minKeywordsValidator },
                                  { minLengthValidator.Slug, minLengthValidator },
                                  { refValidator.Slug, refValidator },
                                  { startKeywordValidator.Slug, startKeywordValidator },
                                  { uniqueValidator.Slug, uniqueValidator },
                            };
        }

        public List<RuleMessage> Validate(
          List<PageChunk> c,
          Dictionary<string, Rule> r)
        {
            List<RuleMessage> messages = new List<RuleMessage>();
            foreach (var chunk in c)
            {
                if (string.IsNullOrWhiteSpace(chunk.Key))
                {
                    logger.LogError("No slug for chunk : " + chunk.Value);
                    continue;
                }

                var v = _ruleValidators[chunk.Key];
                var m = v.Validate(chunk, r[chunk.Key]);
                if (m != null)
                {
                    messages.Add(m);
                }
            }

            return messages;
        }
    }
}
