using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneZipFile))]
namespace App1.WinPhone
{
    public class WinPhoneZipFile : IZipFile
    {
        public async Task<IZipArchive> OpenRead(string filePath)
        {
            const string booksFolderName = "Xamarin eBooks";
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder.GetFolderAsync(booksFolderName).GetResults();
            var file = await localFolder.GetFileAsync(filePath);

            IRandomAccessStreamWithContentType randomStream = await file.OpenReadAsync();
            Stream stream = randomStream.AsStream();
            ZipArchive archive = new ZipArchive(stream);
            WinPhoneZipArchive winPhoneZipArchive = new WinPhoneZipArchive(archive);
            return winPhoneZipArchive;
        }
    }
}
