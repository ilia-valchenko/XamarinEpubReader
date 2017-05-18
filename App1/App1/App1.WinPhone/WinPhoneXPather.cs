using System.Linq;
using System.Xml;
using System.Xml.Linq;
//using System.Xml.XPath;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneXPather))]
namespace App1.WinPhone
{
    public class WinPhoneXPather : IXPather
    {
        public XElement SelectElement(XDocument containerDocument, string rule, XmlNamespaceManager manager)
        {
            var descendats = containerDocument.Descendants().ToList();
            var el = containerDocument.Element("name");
            var root = containerDocument.Root;
            var elements = containerDocument.Elements().ToList();

            //containerDocument.XPathSelectElement("exp");
            
            //XElement element = containerDocument.XPathSelectElement(rule, manager);
            //return element;

            var first1 = descendats.First();
            var first2 = first1.Descendants().First();

            return first2.Descendants().First();
        }
    }
}
                                                                                                                                                                                   