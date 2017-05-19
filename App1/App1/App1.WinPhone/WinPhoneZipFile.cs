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
        private const string booksFolderName = "Xamarin eBooks";

        public async Task<IZipArchive> OpenReadAsync(string filePath)
        {
            var localFolder = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFolderAsync(booksFolderName);
            var file = await localFolder.GetFileAsync(filePath);

            IRandomAccessStreamWithContentType randomStream = await file.OpenReadAsync();
            Stream stream = randomStream.AsStream();
            ZipArchive archive = new ZipArchive(stream);
            WinPhoneZipArchive winPhoneZipArchive = new WinPhoneZipArchive(archive);
            return winPhoneZipArchive;
        }
    }
}
