using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using HtmlAgilityPack;
using Xamarin.Forms;

namespace App1.Models.ApplicationPages.BookPages
{
    /// <summary>
    /// This class represents a default book page which contains text content.
    /// </summary>
    public class BookTextPageViewModel : BookPage
    {
        private readonly WebView webView;

        public BookTextPageViewModel(EpubChapter chapter)
        {
            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(htmlText);

            var bodyOriginal =
                document.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                    .ChildNodes.FirstOrDefault(f => f.Name == "body");

            //IFiler filer = DependencyService.Get<IFiler>();
            //HtmlDocument pageTemplate = new HtmlDocument();
            //Stream stream = filer.GetResourceFileStream("index.html");
            //pageTemplate.Load(stream);

            //var textContainer = pageTemplate.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
            //    .ChildNodes.FirstOrDefault(f => f.Name == "body")
            //    .ChildNodes.FirstOrDefault(d => d.Id == "text-container");

            ////textContainer.ChildNodes.Add(bodyOriginal);

            //foreach (var child in bodyOriginal.ChildNodes)
            //{
            //    textContainer.ChildNodes.Add(child);
            //}

            //webView = new WebView
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};

            //IHtmlHelper htmlHelper = DependencyService.Get<IHtmlHelper>();
            //string cssText = htmlHelper.GetCssText("style.css");

            webView.Source = new HtmlWebViewSource
            {
                //Html = htmlText/*pageTemplate.DocumentNode.OuterHtml*/ /*bookHtmlPage.ToString()*/,
                BaseUrl = string.Format("file:///android_asset/Content/{0}", "index.html")
            };
            this.Content = webView;

            #region Test scroll to last position

            this.Appearing += this.ScrollToLastPosition;

            // test
            //bookPage.Appearing += (osender, oargs) =>
            //{
            //    //DisplayAlert("Topic", "Hello creator", "Cancel");
            //    bool isTextPage = osender is BookTextPageViewModel;
            //    if (isTextPage)
            //    {
            //        BookTextPageViewModel textPage = osender as BookTextPageViewModel;
            //        textPage.webView.Eval(string.Format("window.scrollTo(0, 1000)"));
            //    }
            //}; 

            #endregion
        }

        private void ScrollToLastPosition(object sender, EventArgs args)
        {
            
        }

        private void ShowAnimationWhilePageIsScrolling()
        {

        }
    }
}
