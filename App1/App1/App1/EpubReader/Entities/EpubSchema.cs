using App1.EpubReader.Schema.Navigation;
using App1.EpubReader.Schema.Opf;

namespace App1.EpubReader.Entities
{
    public class EpubSchema
    {
        public EpubPackage Package { get; set; }
        public EpubNavigation Navigation { get; set; }
        public string ContentDirectoryPath { get; set; }
    }
}
