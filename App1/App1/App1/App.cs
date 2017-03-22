﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using Xamarin.Forms;

namespace App1
{
    public class App : Application
    {
        public App()
        {
            string filename = "obitaemij-ostrov.epub";
            IFiler filer = DependencyService.Get<IFiler>();
            string filepath = filer.GetFilePath(filename);
            //string bookPath = "alice-in-wonderland.epub";
            //string archivePath = "doc.zip";

            //IEpubReader epubReader = DependencyService.Get<IEpubReader>();
            //Book book = epubReader.ReadEpub(/*bookPath*/);

            EpubBook book = EpubReader.EpubReader.ReadBook(filepath);

            MainPage = new MainPage(book);
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