namespace App1.Infrastructure.Directory
{
    /// <summary>
    /// This interface exposes methods for creating, moving, and enumerating through directories and subdirectories.
    /// </summary>
    public interface IDirectory
    {
        /// <summary>
        /// This method creates a folder in a root directory.
        /// </summary>
        void CreateRootFolder(string path);
        /// <summary>
        /// This method determines does the directory exist.
        /// </summary>
        /// <returns>Returns true is directory exists.</returns>
        bool DoesDirectoryExist(string path);
    }
}
