﻿using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class PageService : IPageService
    {
        private readonly IHierarchyWalker hierarchyWalker;
        private readonly ILogger<PageService> logger;

        public PageService(IHierarchyWalker hierarchyWalker, ILogger<PageService> logger)
        {
            this.logger = logger;
            this.hierarchyWalker = hierarchyWalker;
        }

        public List<PageChunk> Read(string fileName)
        {
            var texts = new List<PageChunk>();
            PageChunk? c;

            hierarchyWalker.Open(fileName);
            do
            {
                c = hierarchyWalker.Read();
                if (!string.IsNullOrEmpty(c?.Slug))
                {
                    logger.LogInformation($"Read {c.Slug}");
                    texts.Add(c);
                }
            }
            while (c != null);
            hierarchyWalker.Close();

            return texts;
        }
    }
}
