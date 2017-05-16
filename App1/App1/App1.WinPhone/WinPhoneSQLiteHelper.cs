using System.IO;
using Windows.Storage;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneSQLiteHelper))]
namespace App1.WinPhone
{
    public class WinPhoneSQLiteHelper : ISQLite
    {
        /// <summary>
        /// Returns path to the platform-specific local database file.
        /// </summary>
        /// <param name="sqlFilename">The name of a database file.</param>
        /// <returns></returns>
        public string GetLocalDatabaseFilePath(string sqlFilename)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            string path = Path.Combine(localFolder.Path, sqlFilename);
            return path;
        }
    }
}
