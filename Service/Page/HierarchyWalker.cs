using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;
using System;
using System.IO;

namespace rules_of_seo.Service
{
    public class HierarchyWalker : IHierarchyWalker, IDisposable
    {
        private readonly IKeyToSlugResolver slugResolver;
        private readonly ILogger<HierarchyWalker> logger;
        private JsonTextReader? Reader;
        private bool disposedValue;

        public HierarchyWalker(IKeyToSlugResolver slugResolver, ILogger<HierarchyWalker> logger)
        {
            this.slugResolver = slugResolver;
            this.logger = logger;
        }

        public void Open(string textFile)
        {
            var jsonText = File.ReadAllText(textFile);
            Reader = new JsonTextReader(new StringReader(jsonText));
        }

        public PageChunk? Read()
        {
            if(Reader == null)
            {
                logger.LogError("Open file first");
                return null;
            }

            while(Reader.Read())
            {
                if(Reader.TokenType == JsonToken.String)
                {
                    return new PageChunk 
                    { 
                        Slug = slugResolver.Resolve(Reader.Path),
                        Value = Reader.Value?.ToString(),
                        Depth = Reader.Depth
                    };
                }
            }
            

            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && Reader != null)
                {
                    // TODO: dispose managed state (managed objects)
                    Reader.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HierarchyWalker()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
