using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using App1.EpubReader.Entities;
using App1.EpubReader.Utils;
using App1.EpubReader.Interfaces;

namespace App1.EpubReader.RefEntities
{
    public abstract class EpubContentFileRef
    {
        private readonly EpubBookRef epubBookRef;

        public EpubContentFileRef(EpubBookRef epubBookRef)
        {
            this.epubBookRef = epubBookRef;
        }

        public string FileName { get; set; }
        public EpubContentType ContentType { get; set; }
        public string ContentMimeType { get; set; }

        public byte[] ReadContentAsBytes()
        {
            return ReadContentAsBytesAsync().Result;
        }

        public async Task<byte[]> ReadContentAsBytesAsync()
        {
            IZipArchiveEntry contentFileEntry = GetContentFileEntry();
            byte[] content = new byte[(int)contentFileEntry.Length];

            using (Stream contentStream = OpenContentStream(contentFileEntry))
            {
                using (MemoryStream memoryStream = new MemoryStream(content))
                {
                    await contentStream.CopyToAsync(memoryStream).ConfigureAwait(false);
                }
            }
            
            return content;
        }

        public string ReadContentAsText()
        {
            return ReadContentAsTextAsync().Result;
        }

        public async Task<string> ReadContentAsTextAsync()
        {
            using (Stream contentStream = GetContentStream())
            {
                using (StreamReader streamReader = new StreamReader(contentStream))
                {
                    return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
        }

        public Stream GetContentStream()
        {
            Stream stream = OpenContentStream(GetContentFileEntry());
            return stream;
        }

        private IZipArchiveEntry GetContentFileEntry()
        {
            string contentFilePath = ZipPathUtils.Combine(epubBookRef.Schema.ContentDirectoryPath, FileName);
            IZipArchiveEntry contentFileEntry = epubBookRef.EpubArchive.GetEntry(contentFilePath);

            if (contentFileEntry == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "EPUB parsing error: file {0} not found in archive.", contentFilePath));
            }

            if (contentFileEntry.Length > Int32.MaxValue)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "EPUB parsing error: file {0} is bigger than 2 Gb.", contentFilePath));
            }
                
            return contentFileEntry;
        }

        private Stream OpenContentStream(IZipArchiveEntry contentFileEntry)
        {
            Stream contentStream = contentFileEntry.Open();

            if (contentStream == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Incorrect EPUB file: content file \"{0}\" specified in manifest is not found.", FileName));
            }
                
            return contentStream;
        }
    }
}
