using App1.EpubReader.Entities;
using Xamarin.Forms;
using XLabs.Forms.Controls;
//using XLabs.Serialization.JsonNET;

namespace App1.Models.ApplicationPages
{
    public class TestHybridWebViewPage : ContentPage
    {
        private readonly HybridWebView hybrid;

        public TestHybridWebViewPage(EpubChapter chapter)
        {
            this.Title = "HybridWebView page";
            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);
            //JsonSerializer jsonSerializer = new JsonSerializer();
            this.hybrid = new HybridWebView(null/*jsonSerializer*/);

            WebViewSource webViewSource = new HtmlWebViewSource
            {
                Html = htmlText
            };

            this.hybrid.Source = webViewSource;
            this.Content = this.hybrid;
        }
    }
}
