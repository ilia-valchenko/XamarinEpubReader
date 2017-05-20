using System.IO.Compression;
using System.Threading.Tasks;
using App1.Infrastructure.Interfaces;
using App1.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWPZipFile))]
namespace App1.UWP
{
    public class UWPZipFile : IZipFile
    {
        public Task<IZipArchive> OpenReadAsync(string filePath)
        {
            Task<IZipArchive> task = new Task<IZipArchive>(() =>
            {
                ZipArchive zipArchive = ZipFile.OpenRead(filePath);
                UWPZipArchive uwpZipArchive = new UWPZipArchive(zipArchive);
                return uwpZipArchive;
            });

            task.Start();

            return task;
        }
    }
}
