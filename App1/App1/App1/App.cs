using System;
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
            //// TODO: Move it to OnStart method.
            string rootFolder = this.directory.CreateRootFolder(bookDirectoryName);
            //BookRepository bookRepository = null;
            //SettingsRepository settingsRepository = null;

            //try
            //{
            //    bookRepository = new BookRepository(DATABASE_NAME);
            //    settingsRepository = new SettingsRepository(DATABASE_NAME);
            //}
            //catch (SQLite.SQLiteException sqLiteException)
            //{
            //    throw sqLiteException;
            //}
            //catch (Exception exc)
            //{
            //    throw exc;
            //}
            
            //MainPageViewModel mainPage = new MainPageViewModel(bookRepository, settingsRepository);
            //NavigationPage rootPage = new NavigationPage(mainPage)
            //{
            //    BarTextColor = Color.White,
            //    BarBackgroundColor = Color.FromHex("#246A50")
            //};

            //this.MainPage = rootPage;

            this.MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Hello Ilia!"
                        }
                    }
                }
            };
        }

        /// <summary>
        /// This method calls when the application starts. 
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
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
