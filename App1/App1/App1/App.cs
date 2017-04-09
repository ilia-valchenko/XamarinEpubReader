using System.Collections.Generic;
using System.Linq;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using App1.Infrastructure;
using App1.Infrastructure.Directory;
using Xamarin.Forms;
using App1.Models.ApplicationPages;
using App1.Models;
using App1.DAL.Repositories;

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
        /// The name of the database file.
        /// </summary>
        private const string DATABASE_NAME = "books.db";

        /// <summary>
        /// Initialize the instance of <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.filer = DependencyService.Get<IFiler>();
            this.directory = DependencyService.Get<IDirectory>();

            //IScreenHelper screenHelper = DependencyService.Get<IScreenHelper>();
            //int width = screenHelper.ScreenWidth;
            //int height = screenHelper.ScreenHeight;

            IEnumerable<string> filesPath = this.filer.GetFilesPaths(FileExtension.EPUB);
            IEnumerable<EpubBook> epubBooks = filesPath.Select(f => EpubReader.EpubReader.ReadBook(f)).ToList();
            List<BookViewModel> books = epubBooks.Select(b => new BookViewModel(b)).ToList();

            BookRepository bookRepository = new BookRepository(DATABASE_NAME);

            MainPageViewModel mainPage = new MainPageViewModel(/*books*/ bookRepository);
            NavigationPage rootPage = new NavigationPage(mainPage);

            rootPage.BarTextColor = Color.White;
            rootPage.BarBackgroundColor = Color.FromHex("#246A50");

            // ------------ try to set icon for main page -----------------
            //rootPage.Icon = new FileImageSource
            //{
            //    File = "icon.png"
            //};

            //rootPage.Icon = string.Format("{0}{1}.png", Device.OnPlatform("Icons/", "", "Assets/Resources/draeable/"), "icon.png");

            //NavigationPage.SetTitleIcon(mainPage, "icon.png");
            // --------------- end of ------------------------------

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
