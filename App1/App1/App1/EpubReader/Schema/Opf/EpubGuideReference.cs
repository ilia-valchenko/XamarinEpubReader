using System.Globalization;

namespace App1.EpubReader.Schema.Opf
{
    public class EpubGuideReference
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Type: {0}, Href: {1}", Type, Href);
        }
    }
}
