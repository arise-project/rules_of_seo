using System.Collections.Generic;
using System.IO;

namespace rules_of_seo.Model
{
    public class PageFile
    {
        public PageFile(string file)
        {
            File = file ?? throw new System.ArgumentNullException(nameof(file));
            Chunks = new List<PageChunk>();
        }

        public string Segment => string.IsNullOrWhiteSpace(File) ? "" :  new DirectoryInfo(Path.GetDirectoryName(File)).Name;
        public List<PageChunk> Chunks { get; set; }
        public string File {get;set;}
    }
}