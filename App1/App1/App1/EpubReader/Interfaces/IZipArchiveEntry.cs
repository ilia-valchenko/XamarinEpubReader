using System.IO;

namespace App1.EpubReader.Interfaces
{
    public interface IZipArchiveEntry
    {
        long Length { get; }
        Stream Open();
    }
}
