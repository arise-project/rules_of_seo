﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using rules_of_seo.Config;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;
using rules_of_seo.Service.Interfaces;
using rules_of_seo.Validation.Interfaces;

namespace rules_of_seo.Service
{
    public class ValidationUnit : IValidationUnit
    {
        private readonly AppConfig _config;
        private readonly IRuleService _ruleService;
        private readonly IPageService _pageService;
        private readonly IValidator _validator;
        private readonly ILogger<ValidationUnit> logger;
        private readonly ISeoRepository seoRepository;

        public ValidationUnit(
            IOptions<AppConfig> config,
            IRuleService ruleService,
            IPageService pageService,
            IValidator validator,
            ISeoRepository seoRepository,
            ILogger<ValidationUnit> logger
            )
        {
            _config = config.Value;
            _ruleService = ruleService;
            _pageService = pageService;
            _validator = validator;
            this.logger = logger;
            this.seoRepository = seoRepository;
        }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(_config.App))
            {
                logger.LogError("Set Config App");
                throw new Exception();
            }

            // if (string.IsNullOrWhiteSpace(_config.SettingsFile))
            // {
            //     logger.LogError("Set Config SettingsFile");
            //     throw new Exception();
            // }

            if (string.IsNullOrWhiteSpace(_config.TextFolder))
            {
                logger.LogError("Set Config TextFolder");
                throw new Exception();
            }

            seoRepository.Read();

            var rules = _ruleService.GetRules();
            var pages = new List<PageFile>();
            foreach (var textFile in Directory.GetFiles(
                Path.Combine(_config.TextFolder, _config.App),
                "*.json",
                SearchOption.TopDirectoryOnly))
            {
                pages.Add(
                    new PageFile(textFile)
                    {
                        Chunks = _pageService.Read(textFile)
                    });
            }

            foreach (var page in pages)
            {
                var messages = _validator.Validate(page.Chunks, rules);
                foreach (var m in messages)
                {
                    if (m == null)
                    {
                        Console.WriteLine("No iformation for page " + page.File);
                    }
                    else
                    {
                        Console.WriteLine("Page " + page.File);
                        Console.WriteLine(m.ToString());
                    }
                }
            }
        }
    }
}
