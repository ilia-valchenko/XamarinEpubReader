namespace App1.EpubReader.Interfaces
{
    public interface IZipFile
    {
        IZipArchive OpenRead(string filePath);
    }
}
