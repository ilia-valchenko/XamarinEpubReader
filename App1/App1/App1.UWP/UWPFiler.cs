using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App1.Infrastructure;
using App1.Infrastructure.Interfaces;
using App1.UWP;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(UWPFiler))]
namespace App1.UWP
{
    public class UWPFiler : IFiler
    {
        private const string booksFolder = "Xamarin eBooks";

        public Task<bool> DoesFileExistAsync(string filepath)
        {
            Task<bool> task = new Task<bool>(() =>
            {
                bool doesFileExist = File.Exists(filepath);
                return doesFileExist;
            });

            task.Start();

            return task;
        }

        public string GetFilePath(string filename)
        { 
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string filepath = Path.Combine(localFolder.Path, booksFolder, filename);
            return filepath;
        }

        public Task<IEnumerable<string>> GetFilesPathsAsync(FileExtension fileExtension)
        {
            Task<IEnumerable<string>> task = new Task<IEnumerable<string>>(() =>
            {
                string extension = Enum.GetName(typeof(FileExtension), FileExtension.EPUB).ToLower();
                StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                string applicationFolderDirectory = Path.Combine(localFolder.Path, booksFolder);

                DirectoryInfo directoryInfo;

                try
                {
                    directoryInfo = new DirectoryInfo(applicationFolderDirectory);
                }
                catch (Exception exception)
                {
                    throw;
                }


                FileInfo[] files = directoryInfo.GetFiles($"*.{extension}");

                IEnumerable<string> filesPaths = files.Select(f => f.DirectoryName + "/" + f.Name);
                return filesPaths;
            });

            task.Start();

            return task;
        }

        public Task<Stream> GetResourceFileStreamAsync(string filename)
        {
            Task<Stream> task = new Task<Stream>(() =>
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
            });

            task.Start();

            return task;
        }
    }
}
