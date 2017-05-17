﻿using System.IO;
using Windows.Storage;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneHtmlHelper))]
namespace App1.WinPhone
{
    public class WinPhoneHtmlHelper : IHtmlHelper
    {
        public string GetTextFromFile(string filename)
        {
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = localFolder.GetFileAsync(filename).GetResults();
            var openReadResult = file.OpenReadAsync().GetResults();
            Stream stream = openReadResult.AsStream();

            string text;

            using (StreamReader streamReader = new StreamReader(stream))
            {
                text = streamReader.ReadToEnd();
            }

            text = text.Replace("\r\n", string.Empty);
            text = text.Trim();

            return text;
        }
    }
}