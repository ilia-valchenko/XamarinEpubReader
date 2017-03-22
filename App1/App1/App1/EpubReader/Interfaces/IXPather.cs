using System.Xml;
using System.Xml.Linq;

namespace App1.EpubReader.Interfaces
{
    public interface IXPather
    {
        XElement SelectElement(XDocument containerDocument, string rule, XmlNamespaceManager manager);
    }
}
