using System.Collections.Generic;
using System.Linq;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using App1.Infrastructure;
using App1.Infrastructure.Directory;
using Xamarin.Forms;
using App1.Models.ApplicationPages;
using App1.Models;

namespace App1
{
    /// <summary>
    /// The application class.
    /// </summary>
    public class App : Application
    {
        /// <summary>
        /// The name of the directory which will contain eBooks.
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

        /// <summary>
        /// Initialize the instance of <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.filer = DependencyService.Get<IFiler>();
            this.directory = DependencyService.Get<IDirectory>();

            IEnumerable<string> filesPath = this.filer.GetFilesPaths(FileExtension.EPUB);
            IEnumerable<EpubBook> epubBooks = filesPath.Select(f => EpubReader.EpubReader.ReadBook(f));
            List<BookViewModel> books = epubBooks.Select(b => new BookViewModel(b)).ToList();

            MainPageViewModel mainPage = new MainPageViewModel(books);
            NavigationPage rootPage = new NavigationPage(mainPage);

            this.MainPage = rootPage;
        }

        /// <summary>
        /// This method calls when the application starts. 
        /// </summary>
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
