using EpubReaderXamarinForms.EpubReader.Schema.Navigation;
using EpubReaderXamarinForms.EpubReader.Schema.Opf;

namespace EpubReaderXamarinForms.EpubReader.Entities
{
    public class EpubSchema
    {
        public EpubPackage Package { get; set; }
        public EpubNavigation Navigation { get; set; }
        public string ContentDirectoryPath { get; set; }
    }
}
