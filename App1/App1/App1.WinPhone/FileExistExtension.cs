using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace App1.WinPhone
{
    public static class FileExistExtension
    {
        public static async Task<bool> FileExists(this StorageFolder folder, string fileName)
        {
            try
            {
                StorageFile file = await folder.GetFileAsync(fileName);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
