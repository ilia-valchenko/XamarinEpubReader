using System.IO;
using App1.Infrastructure.Interfaces;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWPDirectory))]
namespace App1.UWP
{
    /// <summary>
    /// This class represents an implementation of IDirectory interface by using methods from System.IO.Directory class.
    /// </summary>
    public class UWPDirectory : IDirectory
    {
        /// <summary>
        /// Creates a folder in a root directory.
        /// </summary>
        /// <param name="folderName">The name of a new folder.</param>
        /// <returns>Returns the path to the new folder.</returns>
        public string CreateRootFolder(string folderName)
        {
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string currentInstalledLocation = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            string path = Path.Combine(currentInstalledLocation, folderName);
            DirectoryInfo info = Directory.CreateDirectory(path);
            return path;
        }

        /// <summary>
        /// Gets a value indicating whether the directory exists.
        /// </summary>
        /// <param name="path">The full path of a directory.</param>
        /// <returns>Returns true if directory exists.</returns>
        public bool DoesDirectoryExist(string path)
        {
            bool doesDirectoryExist = Directory.Exists(path);
            return doesDirectoryExist;
        }
    }
}
