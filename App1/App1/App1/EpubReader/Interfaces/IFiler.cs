namespace App1.EpubReader.Interfaces
{
    public interface IFiler
    {
        bool DoesFileExist(string filepath);
        string GetFilePath(string filename);
    }
}
