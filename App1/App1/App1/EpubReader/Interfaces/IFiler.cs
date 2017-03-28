using System.Collections.Generic;
using App1.Infrastructure;

namespace App1.EpubReader.Interfaces
{
    /// <summary>
    /// This interface represent the level of abstraction which provides basic file operations. 
    /// </summary>
    public interface IFiler
    {
        /// <summary>
        /// This method checks if the file exists.
        /// </summary>
        /// <param name="filepath">The path for a file.</param>
        /// <returns>Returns true is a file exists.</returns>
        bool DoesFileExist(string filepath);
        /// <summary>
        /// This method returns the full path of the file.
        /// </summary>
        /// <param name="filename">The name of the file with extension.</param>
        /// <returns>Returns string which represents the full path of the file.</returns>
        string GetFilePath(string filename);
        /// <summary>
        /// This method returns names of the files which have a given extension.
        /// </summary>
        /// <param name="fileExtensions">The extension of the file.</param>
        /// <returns>Returns names of the files with their extensions.</returns>
        IEnumerable<string> GetFilesPaths(FileExtension fileExtensions);
    }
}
