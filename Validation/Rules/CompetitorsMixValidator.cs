using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class CompetitorsMixValidator : ICompetitorsMixValidator
    {
        private readonly ISeoRepository _seoRepository;
        public CompetitorsMixValidator(ISeoRepository seoRepository)
        {
			_seoRepository = seoRepository;
        }
        
        public string Slug {get; } = "competitors-mix";
	
		// check is any sentences of competitors exists. Better to copy more from competitors.
        public RuleMessage Validate(PageChunk c, Rule r)
        {
            if(r.CompetitorsMix != true)
            {
                return null;
            }

            return null;
        }
    }
}
