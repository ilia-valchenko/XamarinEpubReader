using System;

namespace App1.Infrastructure.Interfaces
{
    public interface IZipArchive : IDisposable
    {
        IZipArchiveEntry GetEntry(string entryName);
    }
}
