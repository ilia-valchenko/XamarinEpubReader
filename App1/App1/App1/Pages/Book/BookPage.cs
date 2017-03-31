using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using App1.EpubReader.Entities;
using App1.EpubReader.Schema.Opf;
using Xamarin.Forms;

namespace App1.Pages.Book
{
    public class BookPage : ContentPage
    {
        private readonly StackLayout panel;

        public BookPage(EpubBook book)
        {
            panel = new StackLayout();

            EpubGuideReference coverPageReference = book.Schema.Package.Guide.FirstOrDefault(reference => String.Compare(reference.Type, "cover", StringComparison.OrdinalIgnoreCase) == 0);
            if (coverPageReference != null)
            {
                EpubTextContentFile coverPage;
                if (book.Content.Html.TryGetValue(coverPageReference.Href, out coverPage))
                {
                    var imageContent = coverPage.Content;
                }
            }

            //string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            //foreach (EpubManifestItem manifestItem in book.Schema.Package.Manifest)
            //{
            //    HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource
            //    {
            //        BaseUrl = manifestItem.Href
            //    };

            //    this.panel.Children.Add(new WebView
            //    {
            //        Source = htmlWebViewSource
            //    });
            //}

            HtmlWebViewSource htmlWebViewSource = new HtmlWebViewSource
            {
                BaseUrl = book.Schema.Package.Manifest.ElementAt(2).Href
            };

            this.panel.Children.Add(new WebView
            {
                Source = htmlWebViewSource
            });
        }
    }
}
