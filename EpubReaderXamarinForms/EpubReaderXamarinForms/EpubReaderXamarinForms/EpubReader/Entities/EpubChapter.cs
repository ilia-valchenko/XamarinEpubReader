using System.Collections.Generic;
using System.Globalization;

namespace EpubReaderXamarinForms.EpubReader.Entities
{
    public class EpubChapter
    {
        public string Title { get; set; }
        public string ContentFileName { get; set; }
        public string Anchor { get; set; }
        public string HtmlContent { get; set; }
        public List<EpubChapter> SubChapters { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Title: {0}, Subchapter count: {1}", Title, SubChapters.Count);
        }
    }
}
