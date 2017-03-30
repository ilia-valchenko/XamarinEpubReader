using System;
using System.Collections.Generic;
using System.Globalization;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App1.EpubReader.RefEntities;
using App1.EpubReader.Schema.Opf;
using Xamarin.Forms;

namespace App1.EpubReader.Readers
{
    internal static class BookCoverReader
    {
        public static async Task<Image> ReadBookCoverAsync(EpubBookRef bookRef)
        {
            List<EpubMetadataMeta> metaItems = bookRef.Schema.Package.Metadata.MetaItems;

            if (metaItems == null || !metaItems.Any())
            {
                return null;
            }
                
            EpubMetadataMeta coverMetaItem = metaItems.FirstOrDefault(metaItem => string.Compare(metaItem.Name, "cover", StringComparison.OrdinalIgnoreCase) == 0);

            if (coverMetaItem == null)
            {
                return null;
            }

            if (String.IsNullOrEmpty(coverMetaItem.Content))
            {
                throw new Exception("Incorrect EPUB metadata: cover item content is missing.");
            }
                
            EpubManifestItem coverManifestItem = bookRef.Schema.Package.Manifest.FirstOrDefault(manifestItem => String.Compare(manifestItem.Id, coverMetaItem.Content, StringComparison.OrdinalIgnoreCase) == 0);

            if (coverManifestItem == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Incorrect EPUB manifest: item with ID = \"{0}\" is missing.", coverMetaItem.Content));
            }
                
            EpubByteContentFileRef coverImageContentFileRef;

            if (!bookRef.Content.Images.TryGetValue(coverManifestItem.Href, out coverImageContentFileRef))
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Incorrect EPUB manifest: item with href = \"{0}\" is missing.", coverManifestItem.Href));
            }
                
            byte[] coverImageContent = await coverImageContentFileRef.ReadContentAsBytesAsync().ConfigureAwait(false);

            using (MemoryStream coverImageStream = new MemoryStream(coverImageContent))
            {
                Image image = new Image();
                //return await Task.Run(() => Image.FromStream(coverImageStream)).ConfigureAwait(false);
                Func<Stream> stream = () => coverImageStream;
                image.Source = ImageSource.FromStream(stream);
                return await Task.Run(() => image).ConfigureAwait(false);
            } 
        }
    }
}
