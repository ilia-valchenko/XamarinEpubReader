using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using EpubReaderXamarinForms.EpubReader.Utils;
using Xamarin.Forms;
using EpubReaderXamarinForms.EpubReader.Interfaces;

namespace EpubReaderXamarinForms.EpubReader.Readers
{
    internal static class RootFilePathReader
    {
        public static async Task<string> GetRootFilePathAsync(string filename)
        {
            const string EPUB_CONTAINER_FILE_PATH = "META-INF/container.xml";




            // fix it
            ZipArchiveEntry containerFileEntry = epubArchive.GetEntry(EPUB_CONTAINER_FILE_PATH);
            if (containerFileEntry == null)
                throw new Exception(String.Format("EPUB parsing error: {0} file not found in archive.", EPUB_CONTAINER_FILE_PATH));




            XDocument containerDocument;
            IZipper zipper = DependencyService.Get<IZipper>();
            IXPather xPather = DependencyService.Get<IXPather>();

            //using (Stream containerStream = containerFileEntry.Open())
            using (Stream containerStream = zipper.GetStream(filename, EPUB_CONTAINER_FILE_PATH))
            {
                containerDocument = await XmlUtils.LoadDocumentAsync(containerStream).ConfigureAwait(false);
            }
                
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            xmlNamespaceManager.AddNamespace("cns", "urn:oasis:names:tc:opendocument:xmlns:container");


            // fix it
            XElement rootFileNode = containerDocument.XPathSelectElement("/cns:container/cns:rootfiles/cns:rootfile", xmlNamespaceManager);



            XElement rootFileNode = xPather.SelectElement(containerDocument, "/cns:container/cns:rootfiles/cns:rootfile", xmlNamespaceManager);

            return rootFileNode.Attribute("full-path").Value;
        }
    }
}
