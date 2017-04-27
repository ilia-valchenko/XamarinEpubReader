using System.IO;

namespace App1.Infrastructure.Interfaces
{
    public interface IZipArchiveEntry
    {
        long Length { get; }
        Stream Open();
    }
}
