using System.IO;
using System.IO.Compression;
using App1.Infrastructure.Interfaces;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWPZipArchiveEntry))]
namespace App1.UWP
{
    public class UWPZipArchiveEntry : IZipArchiveEntry
    {
        private readonly ZipArchiveEntry zipArchiveEntry;

        public UWPZipArchiveEntry()
        {
        }

        public UWPZipArchiveEntry(ZipArchiveEntry zipArchiveEntry)
        {
            this.zipArchiveEntry = zipArchiveEntry;
        }

        public long Length
        {
            get
            {
                return this.zipArchiveEntry.Length;
            }
        }

        public Stream Open()
        {
            Stream stream = zipArchiveEntry.Open();
            return stream;
        }
    }
}
