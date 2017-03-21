using System.Xml;
using System.Xml.Linq;

namespace EpubReaderXamarinForms.EpubReader.Interfaces
{
    public interface IXPather
    {
        XElement SelectElement(XDocument document, string rule, XmlNamespaceManager namespaceManager);
    }
}
