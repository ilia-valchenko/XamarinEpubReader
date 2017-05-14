using System.IO.Compression;
using App1.Infrastructure.Interfaces;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWPZipFile))]
namespace App1.UWP
{
    public class UWPZipFile : IZipFile
    {
        public IZipArchive OpenRead(string filePath)
        {
            ZipArchive zipArchive = ZipFile.OpenRead(filePath);
            UWPZipArchive uwpZipArchive = new UWPZipArchive(zipArchive);
            return uwpZipArchive;
        }
    }
}
