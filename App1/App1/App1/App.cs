using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using Xamarin.Forms;
using App1.Pages;

namespace App1
{
    public class App : Application
    {
        public App()
        {
            string filename = "obitaemij-ostrov.epub";
            //string bookPath = "alice-in-wonderland.epub";
            IFiler filer = DependencyService.Get<IFiler>();
            string filepath = filer.GetFilePath(filename);

            List<EpubBook> books = new List<EpubBook>
            {
                EpubReader.EpubReader.ReadBook(filepath)
            };

            MainPage mainPage = new MainPage(books);
            NavigationPage rootPage = new NavigationPage(mainPage);
            //MainPage = new MainPage(books);
            this.MainPage = rootPage;
        }

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
