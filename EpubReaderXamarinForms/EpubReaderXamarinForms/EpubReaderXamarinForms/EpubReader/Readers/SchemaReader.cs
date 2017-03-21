using System.Threading.Tasks;
using EpubReader.Entities;
using EpubReaderXamarinForms.EpubReader.Utils;
using EpubReaderXamarinForms.EpubReader.Schema.Navigation;
using EpubReaderXamarinForms.EpubReader.Schema.Opf;

namespace EpubReaderXamarinForms.EpubReader.Readers
{
    internal static class SchemaReader
    {
        public static async Task<EpubSchema> ReadSchemaAsync(string filename/*ZipArchive epubArchive*/)
        {
            EpubSchema result = new EpubSchema();
            string rootFilePath = await RootFilePathReader.GetRootFilePathAsync(filename).ConfigureAwait(false);
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
