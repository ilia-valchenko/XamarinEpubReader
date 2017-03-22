namespace App1.EpubReader.Utils
{
    internal static class ZipPathUtils
    {
        public static string GetDirectoryPath(string filePath)
        {
            int lastSlashIndex = filePath.LastIndexOf('/');

            if (lastSlashIndex == -1)
            {
                return string.Empty;
            }
            else
            {
                return filePath.Substring(0, lastSlashIndex);
            }
        }

        public static string Combine(string directory, string fileName)
        {
            if (string.IsNullOrEmpty(directory))
            {
                return fileName;
            }
            else
            {
                return string.Concat(directory, "/", fileName);
            }
        }
    }
}
