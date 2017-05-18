using App1.DAL.Entities;
using App1.EpubReader.Entities;
using App1.Infrastructure.Interfaces;
using App1.Infrastructure.Utilities;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using App1.DAL.Interfaces;
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
        /// The settings entity.
        /// </summary>
        private readonly SettingsEntity settings;

        /// <summary>
        /// The settings repository.
        /// </summary>
        private readonly ISettingsRepository settingsRepository;

        /// <summary>
        /// Initialize a new instance of <see cref="BookTextPageViewModel"/> class.
        /// </summary>
        /// <param name="book">EPUB book.</param>
        /// <param name="settings">The settings entity.</param>
        /// <param name="settingsRepository">The settings repository.</param>
        public BookTextPageViewModel(EpubBook book, SettingsEntity settings, ISettingsRepository settingsRepository)
        {
            this.settings = settings;
            this.settingsRepository = settingsRepository;
            IFiler filer = DependencyService.Get<IFiler>();

            #region Custom HTML template

            HtmlDocument template = new HtmlDocument();
            // Hardcode filename
            Stream stream = filer.GetResourceFileStream("index.html").Result;
            template.Load(stream);

            var script = "<script>var lastPageNumber = " + this.settings.LastPage + "</script>";
            HtmlNode scriptNode = HtmlNode.CreateNode(script);

            var head = template.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                .ChildNodes.FirstOrDefault(f => f.Name == "head");

            head.ChildNodes.Add(scriptNode);

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

            #endregion

            string htmlText = template.DocumentNode.OuterHtml.Replace(@"\", string.Empty);

            this.webView = new WebView
            {
                Source = new HtmlWebViewSource { Html = htmlText },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            
            this.webView.Navigating += this.NavigatingHandler;
            this.Content = this.webView;
        }

        private void NavigatingHandler(object sender, WebNavigatingEventArgs args)
        {
            string url = args.Url;
            var parsedValues = HttpUtility.ParseQueryString(url);
            args.Cancel = true;

            IReflectionHelper reflectionHelper = DependencyService.Get<IReflectionHelper>();
            Type thisType = this.GetType();
            string methodName = parsedValues.First().Value;
            string lastPageNumber = parsedValues.GetValues("lastPageNumber").First();
            MethodInfo method = reflectionHelper.GetMethodInfo(thisType, methodName);
            method.Invoke(this, new object[] { lastPageNumber });
        }

        /// <summary>
        /// This method will save the last page number in database. 
        /// It will call every time when user will switch to a new page.
        /// </summary>
        /// <param name="lastPageNumber">The last page number.</param>
        private void SaveLastPageNumber(string lastPageNumber)
        {
            int number = 1;
            Int32.TryParse(lastPageNumber, out number);
            this.settings.LastPage = number;
            int statusCode = this.settingsRepository.Update(this.settings);
        }
    }
}
