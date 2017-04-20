using System.IO;
using System.IO.Compression;
using Android.Content.Res;
using App1.Droid;
using App1.EpubReader.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DroidZipArchiveEntry))]
namespace App1.Droid
{
    public class DroidZipArchiveEntry : IZipArchiveEntry
    {
        private readonly ZipArchiveEntry zipArchiveEntry;

        public DroidZipArchiveEntry()
        {
        }

        public DroidZipArchiveEntry(ZipArchiveEntry zipArchiveEntry)
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