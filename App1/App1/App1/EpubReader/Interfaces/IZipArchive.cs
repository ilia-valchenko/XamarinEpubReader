using System;

namespace App1.EpubReader.Interfaces
{
    public interface IZipArchive : IDisposable
    {
        IZipArchiveEntry GetEntry(string entryName);
    }
}
