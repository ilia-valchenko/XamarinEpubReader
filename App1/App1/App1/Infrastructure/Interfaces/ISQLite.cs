using System.Threading.Tasks;

namespace App1.Infrastructure.Interfaces
{
    /// <summary>
    /// This interface is to determine the location of the database file.
    /// </summary>
    public interface ISQLite
    {
        /// <summary>
        /// Returns path to the platform-specific local database file.
        /// </summary>
        /// <param name="sqlFilename">The name of a database file.</param>
        /// <returns></returns>
        string GetLocalDatabaseFilePath(string sqlFilename);



        ///// <summary>
        ///// Returns path to the platform-specific local database file.
        ///// </summary>
        ///// <param name="sqlFilename">The name of a database file.</param>
        ///// <returns></returns>
        //Task<string> GetLocalDatabaseFilePath(string sqlFilename);
    }
}
