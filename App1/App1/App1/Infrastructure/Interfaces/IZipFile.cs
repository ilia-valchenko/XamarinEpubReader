using System.Threading.Tasks;

namespace App1.Infrastructure.Interfaces
{
    public interface IZipFile
    {
        Task<IZipArchive> OpenRead(string filePath);
    }
}
