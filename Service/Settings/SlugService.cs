﻿using System;
using System.Collections.Generic;
using System.Linq;
using rules_of_seo.Config;
using rules_of_seo.Service.Interface;
using rules_of_seo.Validation.Interfaces;

namespace rules_of_seo.Service
{
    public class SlugService : ISlugService
    {
        public List<IValidator> Assign(
            object root,
            string slug,
            List<IValidator> validators)
        {
            var children =
                root
                    .GetType()
                    .GetProperties()
                    .Select(p =>
                    p.GetCustomAttributes(
                            typeof(SlugAttribute),
                            false)
                    .First());

            throw new NotImplementedException();
        }
    }
}
