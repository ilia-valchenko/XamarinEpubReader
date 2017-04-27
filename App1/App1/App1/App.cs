using App1.DAL.Repositories;
using App1.Infrastructure.Interfaces;
using App1.Models.ApplicationPages;

using Xamarin.Forms;

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
            this.directory = DependencyService.Get<IDirectory>();

            BookRepository bookRepository = new BookRepository(DATABASE_NAME);
            MainPageViewModel mainPage = new MainPageViewModel(bookRepository)
            {
                Icon = Device.OnPlatform("Menu", "icon.png", "Assets/Icons/reload.png")
            };
            NavigationPage rootPage = new NavigationPage(mainPage)
            {
                Icon = Device.OnPlatform("Menu", "icon.png", "Assets/Icons/reload.png")
            };

            rootPage.BarTextColor = Color.White;
            rootPage.BarBackgroundColor = Color.FromHex("#246A50");

            #region Test set page icon

            //NavigationPage.SetTitleIcon(mainPage, "icon.png");

            // ------------ try to set icon for main page -----------------
            //rootPage.Icon = new FileImageSource
            //{
            //    File = "icon.png"
            //};

            //rootPage.Icon = string.Format("{0}{1}.png", Device.OnPlatform("Icons/", "", "Assets/Resources/draeable/"), "icon.png");

            //NavigationPage.SetTitleIcon(mainPage, "icon.png");
            // --------------- end of ------------------------------ 
            #endregion

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
