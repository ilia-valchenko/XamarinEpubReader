using System.IO;
using App1.Infrastructure.Interfaces;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWPSQLite))]
namespace App1.UWP
{
    /// <summary>
    /// This is the implementation of the ISQLite interface for UWP project.
    /// </summary>
    public class UWPSQLite : ISQLite
    {
        /// <summary>
        /// Returns path to the platform-specific local database file.
        /// </summary>
        /// <param name="sqlFilename">The name of a database file.</param>
        /// <returns></returns>
        public string GetLocalDatabaseFilePath(string sqlFilename)
        {
            string path = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            path = Path.Combine(path, sqlFilename);
            return path;
        }
    }
}
