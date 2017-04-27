using System.Xml;
using System.Xml.Linq;

namespace App1.Infrastructure.Interfaces
{
    /// <summary>
    /// This interface provides some operations from the XPath. 
    /// </summary>
    public interface IXPather
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerDocument"></param>
        /// <param name="rule"></param>
        /// <param name="manager"></param>
        /// <returns></returns>
        XElement SelectElement(XDocument containerDocument, string rule, XmlNamespaceManager manager);
    }
}
