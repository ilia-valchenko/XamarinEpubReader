using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using App1.Infrastructure.Interfaces;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWPXPather))]
namespace App1.UWP
{
    public class UWPXPather : IXPather
    {
        public UWPXPather()
        {
        }

        public XElement SelectElement(XDocument containerDocument, string rule, XmlNamespaceManager manager)
        {
            XElement element = containerDocument.XPathSelectElement(rule, manager);
            return element;
        }
    }
}
