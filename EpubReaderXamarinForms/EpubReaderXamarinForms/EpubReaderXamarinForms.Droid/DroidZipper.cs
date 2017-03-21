using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using EpubReaderXamarinForms.EpubReader.Interfaces;

namespace EpubReaderXamarinForms.Droid
{
    public class DroidZipper : IZipper
    {
        public Stream GetStream(string filename, string entryName)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("The book file doesn't exist.");
            }

            ZipArchive zipArchive = ZipFile.OpenRead(filename);
            ZipArchiveEntry zipArchiveEntry = zipArchive.GetEntry(entryName);

            if (zipArchiveEntry == null)
            {
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Parsing error: entry {0} not found in archive.", entryName));
            }

            Stream stream = zipArchiveEntry.Open();
            return stream;
        }
    }
}