namespace App1.Infrastructure.Interfaces
{
    public interface IZipFile
    {
        IZipArchive OpenRead(string filePath);
    }
}
