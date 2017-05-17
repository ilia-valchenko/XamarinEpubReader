using System.IO.Compression;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneZipArchive))]
namespace App1.WinPhone
{
    public class WinPhoneZipArchive : IZipArchive
    {
        private readonly ZipArchive zipArchive;

        public WinPhoneZipArchive(ZipArchive zipArchive)
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
            WinPhoneZipArchiveEntry winPhoneZipArchiveEntry = new WinPhoneZipArchiveEntry(zipArchiveEntry);
            return winPhoneZipArchiveEntry;
        }
    }
}
