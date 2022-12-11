using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Validation.Rules.Interface;

namespace rules_of_seo.Validation.Rules
{
    public class AllowAdditionParagraphValidator : IAllowAdditionParagraphValidator
    {
        public const string ParagraphTagBeg = "<p>";
        public const string ParagraphTagBeg = "</p>";

        public RuleMessage Validate(PageChunk c, Rule r)
        {
            int bc = 0, ec = 0, b, e;

            do
            {

            }
            while(b!= -1);

            do
            {

            }
            while(b!= -1);

            if(bc!=ec)
            {
                
            }

            return new RuleMessage 
            { 
                MessageLevel = MessageLevel.Info,
                
            };
        }
    }
}
