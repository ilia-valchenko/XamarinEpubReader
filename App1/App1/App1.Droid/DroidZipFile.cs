using System.IO.Compression;
using App1.Droid;
using EpubReaderXamarinForms.Droid;
using App1.Infrastructure.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DroidZipFile))]
namespace App1.Droid
{
    public class DroidZipFile : IZipFile
    {
        public IZipArchive OpenRead(string filePath)
        {
            ZipArchive zipArchive = ZipFile.OpenRead(filePath);
            DroidZipArchive droidZipArchive = new DroidZipArchive(zipArchive);
            return droidZipArchive;
        }
    }
}