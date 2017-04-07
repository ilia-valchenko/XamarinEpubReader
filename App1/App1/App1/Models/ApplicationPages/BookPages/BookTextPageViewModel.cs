using System.Linq;
using System.Text;
using Xamarin.Forms;
using App1.EpubReader.Entities;

using HtmlAgilityPack;
using Java.Lang;

namespace App1.Models.ApplicationPages.BookPages
{
    /// <summary>
    /// This class represents a default book page which contains text content.
    /// </summary>
    public class BookTextPageViewModel : BookPage
    {
        /// <summary>
        /// Initialize an instance of <see cref="BookTextPageViewModel"/>
        /// </summary>
        /// <param name="chapter">The book's chapter.</param>
        public BookTextPageViewModel(EpubChapter chapter)
        {
            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            // ---------------- test ------------------------------
            // get content of the body
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlText);
            var bodyOuterHtml =
                document.DocumentNode.ChildNodes.FirstOrDefault(c => c.Name == "html")
                    .ChildNodes.FirstOrDefault(f => f.Name == "body").OuterHtml;

            //HtmlDocument newDocument = new HtmlDocument();

            System.Text.StringBuilder bookHtmlPage = new System.Text.StringBuilder();
            bookHtmlPage.Append("<!DOCTYPE html");
            bookHtmlPage.Append("<html>");
            bookHtmlPage.Append("<head>");
            bookHtmlPage.Append("<meta charset='utf-8'>");

            string styleTag = "<style>h1, h2, h3, h4, h5, h6 { text-align: center; }</style>";
            bookHtmlPage.Append(styleTag);

            bookHtmlPage.Append("</head>");
            bookHtmlPage.Append(bodyOuterHtml);
            bookHtmlPage.Append("</html>");

            //HtmlNode htmlNode = HtmlNode.CreateNode(bookHtmlPage.ToString());
            //newDocument.DocumentNode.AppendChild(htmlNode);
            //var outherHtml = newDocument.DocumentNode.OuterHtml;




            // ------------------ end of test ----------------------------

            //HtmlWebViewSource source = new HtmlWebViewSource { Html = htmlText };
            HtmlWebViewSource source = new HtmlWebViewSource { Html = bookHtmlPage.ToString() };

            this.Content = new WebView { Source = source };

            WebView webView = new WebView
            {
                Source = source
            };
            
        }

    }
}
