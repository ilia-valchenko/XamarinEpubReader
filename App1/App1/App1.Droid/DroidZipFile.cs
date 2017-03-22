using System.IO.Compression;
using App1.Droid;
using App1.EpubReader.Interfaces;
using EpubReaderXamarinForms.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DroidZipFile))]
namespace App1.Droid
{
    public class DroidZipFile : IZipFile
    {
        public DroidZipFile()
        { 
        }

        public IZipArchive OpenRead(string filePath)
        {
            ZipArchive zipArchive = ZipFile.OpenRead(filePath);
            DroidZipArchive droidZipArchive = new DroidZipArchive(zipArchive);
            return droidZipArchive;
        }
    }
}