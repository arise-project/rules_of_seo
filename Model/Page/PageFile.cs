using System.Collections.Generic;
using System.IO;

namespace rules_of_seo.Model
{
    public class PageFile
    {
        public PageFile(string file)
        {
            File = file;
        }
        
        public string Segment => new DirectoryInfo(Path.GetDirectoryName(File)).Name;
        public List<PageChunk> Chunks { get; set; }
        public string File {get;set;}
    }
}