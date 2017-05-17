using System.IO;
using System.IO.Compression;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneZipArchiveEntry))]
namespace App1.WinPhone
{
    public class WinPhoneZipArchiveEntry : IZipArchiveEntry
    {
        private readonly ZipArchiveEntry zipArchiveEntry;

        public WinPhoneZipArchiveEntry(ZipArchiveEntry zipArchiveEntry)
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
