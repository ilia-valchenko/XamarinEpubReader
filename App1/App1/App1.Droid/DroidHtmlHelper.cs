using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using App1.EpubReader.Interfaces;
using Xamarin.Forms;
using App1.Infrastructure;

[assembly: Xamarin.Forms.Dependency(typeof(DroidHtmlHelper))]
namespace App1.Droid
{
    public class DroidHtmlHelper : IHtmlHelper
    {
        public string GetCssText(string filename)
        {
            Stream stream = Android.App.Application.Context.Assets.Open(filename);
            string cssText;

            using (StreamReader streamReader = new StreamReader(stream))
            {
                cssText = streamReader.ReadToEnd();
            }

            cssText = cssText.Replace("\r\n", string.Empty);
            cssText = cssText.Trim();

            return cssText;
        }
    }
}