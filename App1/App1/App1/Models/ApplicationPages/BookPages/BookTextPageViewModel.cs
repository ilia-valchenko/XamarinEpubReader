using Xamarin.Forms;
using App1.EpubReader.Entities;

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
            HtmlWebViewSource source = new HtmlWebViewSource { Html = htmlText };

            string[] words = htmlText.Split(' ');
            Rectangle rect = new Rectangle();


            this.Content = new WebView { Source = source };

            // ---------------
            WebView webView = new WebView
            {
                Source = source
            };
            
        }

    }
}
