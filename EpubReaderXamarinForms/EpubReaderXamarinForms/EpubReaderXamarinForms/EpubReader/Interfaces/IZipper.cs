using System.IO;

namespace EpubReaderXamarinForms.EpubReader.Interfaces
{
    public interface IZipper
    {
        Stream GetStream(string filename, string entryName);
    }
}
