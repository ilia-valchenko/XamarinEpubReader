using System;
using System.Collections.Generic;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using App1.Infrastructure;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneFiler))]
namespace App1.WinPhone
{
    public class WinPhoneFiler : IFiler
    {
        private const string booksFolderName = "Xamarin eBooks";

        public bool DoesFileExist(string filepath)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder booksFolder = localFolder.GetFolderAsync(booksFolderName).GetAwaiter().GetResult();
            bool doesFileExist = booksFolder.FileExists(filepath).GetAwaiter().GetResult();

            return doesFileExist;
        }

        public string GetFilePath(string filename)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string filepath = Path.Combine(localFolder.Path, booksFolderName, filename);
            return filepath;
        }

        public async Task<IEnumerable<string>> GetFilesPaths(FileExtension fileExtension)
        {
            //string extension = Enum.GetName(typeof(FileExtension), FileExtension.EPUB).ToLower();
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder booksFolder = localFolder.GetFolderAsync(booksFolderName).GetAwaiter().GetResult();
            IReadOnlyCollection<StorageFile> files = await booksFolder.GetFilesAsync();
            IEnumerable<string> filesPaths = files.Select(f => f.Name);

            return filesPaths;
        }

        public async Task<Stream> GetResourceFileStream(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("The filename can't be null or empty.");
            }

            Stream stream;

            try
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await localFolder.GetFileAsync(filename);
                var openReadResult = await file.OpenReadAsync();
                stream = openReadResult.AsStream();
            }
            catch (Exception exception)
            {
                throw;
            }

            return stream;
        }
    }
}
