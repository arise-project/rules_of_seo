using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class HierarchyWalker : IHierarchyWalker
    {
        private readonly IKeyToSlugResolver slugResolver;
        private readonly ILogger<HierarchyWalker> logger;
        private JsonTextReader? Reader;
        private string fileName;

        public HierarchyWalker(IKeyToSlugResolver slugResolver, ILogger<HierarchyWalker> logger)
        {
            this.slugResolver = slugResolver;
            this.logger = logger;
        }

        public void Open(string textFile)
        {
            logger.LogInformation($"Open {textFile}");
            var jsonText = File.ReadAllText(textFile);
            Reader = new JsonTextReader(new StringReader(jsonText));
            fileName = textFile;
        }

        public PageChunk? Read()
        {
            if (Reader == null)
            {
                logger.LogError("Open file first");
                return null;
            }

            while (Reader.Read())
            {
                if (Reader.TokenType == JsonToken.String)
                {
                    var s = slugResolver.Resolve(Reader.Path);
                    if (s == null)
                    {
                        logger.LogWarning($"Unknown {Reader.Path} {Reader.Depth} {Reader.Value}");
                        continue;
                    }

                    logger.LogInformation($"Read {s} {Reader.Depth} {Reader.Value}");
                    return new PageChunk
                    {
                        Key = slugResolver.Resolve(Reader.Path),
                        Value = Reader.Value?.ToString(),
                        Depth = Reader.Depth
                    };
                }
            }

            return null;
        }

        public void Close()
        {
            if (Reader != null)
            {
                logger.LogInformation("Closed file " + fileName);
                Reader.Close();
            }
        }
    }
}
