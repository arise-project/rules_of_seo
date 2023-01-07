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
                                  { allowAdditionParagraphValidator.RuleName, allowAdditionParagraphValidator },
                                  { checkPlagiatValidator.RuleName, checkPlagiatValidator },
                                  { competitorsMixValidator.RuleName, competitorsMixValidator },
                                  { endKeywordValidator.RuleName, endKeywordValidator },
                                  { firstIncludeOthersValidator.RuleName, firstIncludeOthersValidator },
                                  { isKeywordValidator.RuleName, isKeywordValidator },
                                  { isUrlValidator.RuleName, isUrlValidator },
                                  { maxCompetitorLengthValidator.RuleName, maxCompetitorLengthValidator },
                                  { maxKeywordsValidator.RuleName, maxKeywordsValidator },
                                  { maxLengthValidator.RuleName, maxLengthValidator },
                                  { middleKeywordValidator.RuleName, middleKeywordValidator },
                                  { minKeywordsValidator.RuleName, minKeywordsValidator },
                                  { minLengthValidator.RuleName, minLengthValidator },
                                  { refValidator.RuleName, refValidator },
                                  { startKeywordValidator.RuleName, startKeywordValidator },
                                  { uniqueValidator.RuleName, uniqueValidator },
                            };
        }

        public List<RuleMessage> Validate(
          List<PageChunk> c,
          Dictionary<string, Rule> r)
        {
            List<RuleMessage> messages = new List<RuleMessage>();
            foreach (var chunk in c)
            {
                if (string.IsNullOrWhiteSpace(chunk.Slug))
                {
                    logger.LogError("No slug for chunk : " + chunk.Value);
                    continue;
                }

                var rule = r[chunk.Slug];
                foreach(var validator in _ruleValidators.Values)
                {
                    var m = validator.Validate(chunk, rule);
                    if (m != null)
                    {
                        messages.Add(m);
                    }
                }
            }

            return messages;
        }
    }
}
