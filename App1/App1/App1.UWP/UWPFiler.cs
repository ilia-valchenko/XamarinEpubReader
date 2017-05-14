using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public UWPFiler()
        {
        }

        public bool DoesFileExist(string filepath)
        {
            bool doesFileExist = File.Exists(filepath);
            return doesFileExist;
        }

        public string GetFilePath(string filename)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string filepath = Path.Combine(localFolder.Path, booksFolder, filename);
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
            string applicationFolderDirectory = Path.Combine(localFolder.Path, booksFolder);

            DirectoryInfo directoryInfo;

            try
            {
                directoryInfo = new DirectoryInfo(applicationFolderDirectory);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }

            FileInfo[] files = directoryInfo.GetFiles($"*.{extension}");

            IEnumerable<string> filesPaths = files.Select(f => f.DirectoryName + "/" + f.Name);
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
