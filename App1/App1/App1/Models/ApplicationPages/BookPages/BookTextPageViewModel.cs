using System;
using System.IO;
using System.Linq;
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
        /// <summary>
        /// The web view. 
        /// </summary>
        private readonly WebView webView;

        /// <summary>
        /// Initialize a new instance of <see cref="BookTextPageViewModel"/> class.
        /// </summary>
        /// <param name="chapter"></param>
        public BookTextPageViewModel(EpubChapter chapter)
        {
            #region Body original

            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(htmlText);

            var bodyOriginal =
                document.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                    .ChildNodes.FirstOrDefault(f => f.Name == "body"); 

            #endregion

            IFiler filer = DependencyService.Get<IFiler>();
            HtmlDocument pageTemplate = new HtmlDocument();
            Stream stream = filer.GetResourceFileStream("index.html");
            pageTemplate.Load(stream);

            var textContainer = pageTemplate.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                .ChildNodes.FirstOrDefault(f => f.Name == "body")
                .ChildNodes.FirstOrDefault(d => d.Id == "text-container");

            foreach (var child in bodyOriginal.ChildNodes)
            {
                textContainer.ChildNodes.Add(child);
            }

            #region Add CCS custom CSS style

            var head = pageTemplate.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                    .ChildNodes.FirstOrDefault(f => f.Name == "head");

            IHtmlHelper htmlHelper = DependencyService.Get<IHtmlHelper>();
            string cssText = htmlHelper.GetCssText("style.css");

            HtmlNode style = HtmlNode.CreateNode("<style></style>");
            style.InnerHtml = cssText;

            head.ChildNodes.Add(style);

            #endregion

            webView = new WebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = new HtmlWebViewSource
                {
                    Html = pageTemplate.DocumentNode.OuterHtml
                }
            };

            this.Content = webView;

            #region Test scroll to last position

            this.Appearing += this.ScrollToLastPosition;

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
