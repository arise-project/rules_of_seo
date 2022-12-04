﻿using System.Collections.Generic;
using rules_of_seo.Config;
using rules_of_seo.Model;

namespace rules_of_seo.Validation.Interface
{
    public interface IValidator
    {
        List<RuleMessage> Validate(PageChunk c, Rule r);
    }
}
