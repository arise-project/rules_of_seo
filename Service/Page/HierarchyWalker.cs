using Newtonsoft.Json;
using rules_of_seo.Model;
using rules_of_seo.Service.Interface;

namespace rules_of_seo.Service
{
    public class HierarchyWalker : IHierarchyWalker, IDisposable
    {
        private readonly IKeyToSlugResolver slugResolver;
        private JsonTextReader Reader;
        private bool disposedValue;

        public HierarchyWalker(IKeyToSlugResolver slugResolver)
        {
            this.slugResolver = slugResolver;
        }

        public void Open(string textFile)
        {
            var jsonText = File.ReadAllText(textFile);
            Reader = new JsonTextReader(new StringReader(jsonText));
        }

        public PageChunk Read()
        {
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
                if (disposing)
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
