using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1.Pages.Book
{
    public class BookTextPage : ContentPage
    {
        private readonly StackLayout panel;

        /// <summary>
        /// Initialize an instance of <see cref="BookTextPage"/>
        /// </summary>
        /// <param name="chapter">The book's chapter.</param>
        public BookTextPage(EpubChapter chapter)
        {
            this.Title = "Text page";
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
