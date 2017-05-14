using App1.Infrastructure.Interfaces;
using App1.UWP;
using System.IO.Compression;

[assembly: Xamarin.Forms.Dependency(typeof(UWPZipArchive))]
namespace App1.UWP
{
    public class UWPZipArchive : IZipArchive
    {
        private readonly ZipArchive zipArchive;

        public UWPZipArchive()
        {
        }

        public UWPZipArchive(ZipArchive zipArchive)
        {
            this.zipArchive = zipArchive;
        }

        public void Dispose()
        {
            this.zipArchive.Dispose();
        }

        public IZipArchiveEntry GetEntry(string entryName)
        {
            ZipArchiveEntry zipArchiveEntry = this.zipArchive.GetEntry(entryName);
            UWPZipArchiveEntry uwpZipArchiveEntry = new UWPZipArchiveEntry(zipArchiveEntry);
            return uwpZipArchiveEntry;
        }
    }
}
