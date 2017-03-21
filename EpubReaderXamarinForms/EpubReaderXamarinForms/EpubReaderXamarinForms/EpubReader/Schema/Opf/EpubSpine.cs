using System.Collections.Generic;

namespace EpubReaderXamarinForms.EpubReader.Schema.Opf
{
    public class EpubSpine : List<EpubSpineItemRef>
    {
        public string Toc { get; set; }
    }
}
