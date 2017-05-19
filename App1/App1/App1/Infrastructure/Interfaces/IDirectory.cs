namespace App1.Infrastructure.Interfaces
{
    /// <summary>
    /// This interface exposes methods for creating, moving, and enumerating through directories and subdirectories.
    /// </summary>
    public interface IDirectory
    {
        /// <summary>
        /// This method creates a folder in a root directory.
        /// </summary>
        /// <returns>Returns the path to the new folder.</returns>
        string CreateRootFolder(string path);
        /// <summary>
        /// This method determines does the directory exist.
        /// </summary>
        /// <returns>Returns true is directory exists.</returns>
        bool DoesDirectoryExist(string path);
    }
}
