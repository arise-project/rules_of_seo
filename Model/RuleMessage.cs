﻿using rules_of_seo.Config;
namespace rules_of_seo.Model
{
    public class RuleMessage
    {
        public string Message { get; set; }

        public Rule Rule { get; set; }
        
        public string MessqageLevel { get; set; }
    }
}
