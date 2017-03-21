namespace EpubReaderXamarinForms.EpubReader.Schema.Opf
{
    public class EpubGuideReference
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }

        public override string ToString()
        {
            return string.Format($"Type: {Type}, Href: {Href}");
        }
    }
}
