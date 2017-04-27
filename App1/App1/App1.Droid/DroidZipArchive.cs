using App1.Droid;
using App1.Infrastructure.Interfaces;
using EpubReaderXamarinForms.Droid;
using System.IO.Compression;

[assembly: Xamarin.Forms.Dependency(typeof(DroidZipArchive))]
namespace EpubReaderXamarinForms.Droid
{
    public class DroidZipArchive : IZipArchive
    {
        private readonly ZipArchive zipArchive;

        public DroidZipArchive()
        {           
        }

        public DroidZipArchive(ZipArchive zipArchive)
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
            DroidZipArchiveEntry droidZipArchiveEntry = new DroidZipArchiveEntry(zipArchiveEntry);
            return droidZipArchiveEntry;
        }
    }
}