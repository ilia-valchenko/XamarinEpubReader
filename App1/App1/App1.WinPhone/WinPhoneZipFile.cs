using System.IO;
using System.IO.Compression;
using Windows.Storage.Streams;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneZipFile))]
namespace App1.WinPhone
{
    public class WinPhoneZipFile : IZipFile
    {
        public IZipArchive OpenRead(string filePath)
        {
            //ZipArchive zipArchive = ZipFile.OpenRead(filePath);
            //WinPhoneZipArchive uwpZipArchive = new WinPhoneZipArchive(zipArchive);
            //return uwpZipArchive;

            const string booksFolderName = "Xamarin eBooks";
            const string zipFileName = "popitka-k-begstvy.epub";
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder.GetFolderAsync(booksFolderName).GetResults();
            var file = localFolder.GetFileAsync(zipFileName).GetResults();
            IRandomAccessStreamWithContentType randomStream = file.OpenReadAsync().GetResults();
            Stream stream = randomStream.AsStream();
            ZipArchive archive = new ZipArchive(stream);
            WinPhoneZipArchive winPhoneZipArchive = new WinPhoneZipArchive(archive);
            return winPhoneZipArchive;
        }
    }
}
