using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class RefValidator : IRefValidator
    {
        private readonly ISeoRepository _seoRepository;

        public RefValidator(ISeoRepository seoRepository)
        {
            _seoRepository = seoRepository;
        }

        public string Slug { get; } = "ref";

        //ref is the reference between parend and child slug
        public RuleMessage? Validate(PageChunk c, Rule r)
        {
            if (string.IsNullOrWhiteSpace(r.Ref))
            {
                return null;
            }

            return null;
        }
    }
}
