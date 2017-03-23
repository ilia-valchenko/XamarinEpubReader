using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1
{
    public class BookTextPage : ContentPage
    {
        private readonly StackLayout panel;

        public BookTextPage(EpubChapter chapter)
        {
            panel = new StackLayout();

            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            HtmlWebViewSource source = new HtmlWebViewSource
            {
                Html = htmlText
            };

            this.Content = new WebView
            {
                Source = source,
            };
        }
    }
}
