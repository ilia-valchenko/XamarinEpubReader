using System.IO;
using App1.Droid;
using App1.Infrastructure.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DroidDirectory))]
namespace App1.Droid
{
    /// <summary>
    /// This class represents an implementation of IDirectory interface by using methods from System.IO.Directory class.
    /// </summary>
    public class DroidDirectory : IDirectory
    {
        /// <summary>
        /// Creates a folder in a root directory.
        /// </summary>
        /// <param name="folderName">The name of a new folder.</param>
        /// <returns>Returns the path to the new folder.</returns>
        public string CreateRootFolder(string folderName)
        {
            string externalStorageDirectory = Android.OS.Environment.ExternalStorageDirectory.Path;
            string path = Path.Combine(externalStorageDirectory, folderName);
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