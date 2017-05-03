using App1.DAL.Entities;
using App1.EpubReader.Entities;
using App1.Infrastructure.Interfaces;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using App1.Infrastructure.Utilities;
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
        /// <param name="book">EPUB book.</param>
        public BookTextPageViewModel(EpubBook book, SettingsEntity settings)
        {
            IFiler filer = DependencyService.Get<IFiler>();
            HtmlDocument template = new HtmlDocument();
            // Hardcode filename
            Stream stream = filer.GetResourceFileStream("index.html");
            template.Load(stream);

            var textContainer = template.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                .ChildNodes.FirstOrDefault(f => f.Name == "body")
                .ChildNodes.FirstOrDefault(d => d.Id == "page");

            foreach (var html in book.Content.Html)
            {
                HtmlDocument document = new HtmlDocument();
                string htmlString = html.Value.Content.Replace(@"\", string.Empty);
                document.LoadHtml(htmlString);

                var body =
                document.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                    .ChildNodes.FirstOrDefault(f => f.Name == "body");

                foreach (var child in body.ChildNodes)
                {
                    textContainer.ChildNodes.Add(child);
                }
            }

            string text = template.DocumentNode.OuterHtml.Replace(@"\", string.Empty);

            this.webView = new WebView
            {
                Source = new HtmlWebViewSource
                {
                    Html = text
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // test
            this.webView.Navigating += (sender, args) =>
            {
                var url = args.Url;
                //var encodedUrl = System.Net.WebUtility.UrlEncode(url);
                //var decodeUrl = System.Net.WebUtility.UrlDecode(url);

                HttpUtility httpUtility = new HttpUtility();

                var parsedValues = HttpUtility.ParseQueryString(url);

                args.Cancel = true;
            };

            this.Content = this.webView;
        }

        private void ScrollToLastPosition(object sender, EventArgs args)
        {
            
        }

        private void ShowAnimationWhilePageIsScrolling()
        {

        }

        private void PredefineMethod(int number)
        {
            DisplayAlert("Title", $"Number is: {number}", "Cancel");
        }
    }
}
