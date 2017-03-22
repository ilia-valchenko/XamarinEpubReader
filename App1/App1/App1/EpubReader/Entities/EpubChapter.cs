using System.Collections.Generic;
using System.Globalization;

namespace App1.EpubReader.Entities
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
            string result = string.Format(CultureInfo.InvariantCulture, "Title: {0}, Subchapter count: {1}", Title, SubChapters.Count);
            return result;
        }
    }
}
