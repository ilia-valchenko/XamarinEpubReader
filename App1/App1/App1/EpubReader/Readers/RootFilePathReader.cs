using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using App1.EpubReader.Utils;
using Xamarin.Forms;
using App1.Infrastructure.Interfaces;

namespace App1.EpubReader.Readers
{
    internal static class RootFilePathReader
    {
        public static async Task<string> GetRootFilePathAsync(IZipArchive epubArchive)
        {
            const string EPUB_CONTAINER_FILE_PATH = "META-INF/container.xml";
            IZipArchiveEntry containerFileEntry = epubArchive.GetEntry(EPUB_CONTAINER_FILE_PATH);

            if (containerFileEntry == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "EPUB parsing error: {0} file not found in archive.", EPUB_CONTAINER_FILE_PATH));
            }
                
            XDocument containerDocument;

            using (Stream containerStream = containerFileEntry.Open())
            {
                containerDocument = await XmlUtils.LoadDocumentAsync(containerStream).ConfigureAwait(false);
            }
                
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            xmlNamespaceManager.AddNamespace("cns", "urn:oasis:names:tc:opendocument:xmlns:container");

            //XElement rootFileNode = containerDocument.XPathSelectElement("/cns:container/cns:rootfiles/cns:rootfile", xmlNamespaceManager);
            IXPather xPather = DependencyService.Get<IXPather>();
            XElement rootFileNode = xPather.SelectElement(containerDocument, "/cns:container/cns:rootfiles/cns:rootfile", xmlNamespaceManager);

            return rootFileNode.Attribute("full-path").Value;
        }
    }
}
