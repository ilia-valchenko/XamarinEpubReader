using System.Threading.Tasks;
using App1.EpubReader.Entities;
using App1.EpubReader.Schema.Navigation;
using App1.EpubReader.Schema.Opf;
using App1.EpubReader.Utils;
using App1.Infrastructure.Interfaces;

namespace App1.EpubReader.Readers
{
    internal static class SchemaReader
    {
        public static async Task<EpubSchema> ReadSchemaAsync(IZipArchive epubArchive)
        {
            EpubSchema result = new EpubSchema();
            string rootFilePath = await RootFilePathReader.GetRootFilePathAsync(epubArchive).ConfigureAwait(false);
            string contentDirectoryPath = ZipPathUtils.GetDirectoryPath(rootFilePath);
            result.ContentDirectoryPath = contentDirectoryPath;
            EpubPackage package = await PackageReader.ReadPackageAsync(epubArchive, rootFilePath).ConfigureAwait(false);
            result.Package = package;
            EpubNavigation navigation = await NavigationReader.ReadNavigationAsync(epubArchive, contentDirectoryPath, package).ConfigureAwait(false);
            result.Navigation = navigation;
            return result;
        }
    }
}
