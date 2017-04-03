using System.Collections.Generic;
using System.Linq;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using App1.Pages;
using App1.Infrastructure;
using App1.Infrastructure.Directory;
using Xamarin.Forms;

namespace App1
{
    public class App : Application
    {
        /// <summary>
        /// This string represents the name of the directory which contains electronic books.
        /// </summary>
        private const string bookDirectoryName = "Xamarin eBooks";

        /// <summary>
        /// The filer class. 
        /// </summary>
        private readonly IFiler filer;

        /// <summary>
        /// The directory class.
        /// </summary>
        private readonly IDirectory directory;

        public App()
        {
            this.filer = DependencyService.Get<IFiler>();
            this.directory = DependencyService.Get<IDirectory>();

            IEnumerable<string> filesPath = this.filer.GetFilesPaths(FileExtension.EPUB);
            IEnumerable<EpubBook> books = filesPath.Select(f => EpubReader.EpubReader.ReadBook(f));

            MainPage mainPage = new MainPage(books);
            NavigationPage rootPage = new NavigationPage(mainPage);

            this.MainPage = rootPage;
        }

        protected override void OnStart()
        {
            this.directory.CreateRootFolder(bookDirectoryName);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
