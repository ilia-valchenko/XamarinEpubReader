using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneDirectory))]
namespace App1.WinPhone
{
    /// <summary>
    /// This class represents an implementation of IDirectory interface by using methods from System.IO.Directory class.
    /// </summary>
    public class WinPhoneDirectory : IDirectory
    {
        /// <summary>
        /// Creates a folder in a root directory.
        /// </summary>
        /// <param name="folderName">The name of a new folder.</param>
        /// <returns>Returns the path to the new folder.</returns>
        public string CreateRootFolder(string folderName)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFolder createdFolder = localFolder.CreateFolderAsync(folderName).GetAwaiter().GetResult();

            return createdFolder.Path;
        }

        /// <summary>
        /// Gets a value indicating whether the directory exists.
        /// </summary>
        /// <param name="path">The full path of a directory.</param>
        /// <returns>Returns true if directory exists.</returns>
        public bool DoesDirectoryExist(string path)
        {
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder.GetFolderAsync(path).GetAwaiter().GetResult();
            return folder != null;
        }
    }
}
