using System;
using System.Collections.Generic;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;
using System.IO;
using System.Linq;
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
            bool doesFileExist = localFolder.FileExists(filepath).Result;

            return doesFileExist;
        }

        public string GetFilePath(string filename)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string filepath = Path.Combine(localFolder.Path, booksFolderName, filename);
            return filepath;
        }

        public IEnumerable<string> GetFilesPaths(FileExtension fileExtension)
        {
            string extension;

            try
            {
                extension = Enum.GetName(typeof(FileExtension), FileExtension.EPUB).ToLower();
            }
            catch (ArgumentNullException argumentNullException)
            {
                throw;
            }
            catch (ArgumentException argumentException)
            {
                throw;
            }
            catch (NullReferenceException nullReferenceException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }

            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //string applicationFolderDirectory = Path.Combine(localFolder.Path, booksFolder);
            StorageFolder booksFolder = localFolder.GetFolderAsync(booksFolderName).GetAwaiter().GetResult();

            IReadOnlyCollection<StorageFile> files = booksFolder.GetFilesAsync().GetResults();

            //FileInfo[] files = directoryInfo.GetFiles($"*.{extension}");

            //IEnumerable<string> filesPaths = files.Select(f => f.DirectoryName + "/" + f.Name);

            IEnumerable<string> filesPaths = files.Select(f => f.Name);

            return filesPaths;
        }

        public Stream GetResourceFileStream(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("The filename can't be null or empty.");
            }

            Stream stream;

            try
            {
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = localFolder.GetFileAsync(filename).GetAwaiter().GetResult();
                var openReadResult = file.OpenReadAsync().GetAwaiter().GetResult();
                stream = openReadResult.AsStream();
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }

            return stream;
        }
    }
}
