using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using App1.Droid;
using App1.EpubReader.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DroidXPather))]
namespace App1.Droid
{
    public class DroidXPather : IXPather
    {
        public DroidXPather()
        {
        }

        public XElement SelectElement(XDocument containerDocument, string rule, XmlNamespaceManager manager)
        {
            XElement element = containerDocument.XPathSelectElement(rule, manager);
            return element;
        }
    }
}