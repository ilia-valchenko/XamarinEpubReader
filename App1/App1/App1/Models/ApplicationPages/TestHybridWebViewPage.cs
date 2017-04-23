using App1.EpubReader.Entities;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace App1.Models.ApplicationPages
{
    public class TestHybridWebViewPage : ContentPage
    {
        private readonly HybridWebView hybrid;

        public TestHybridWebViewPage(EpubChapter chapter)
        {
            this.Title = "HybridWebView page";

            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            JsonSerializer jsonSerializer = new JsonSerializer();
            this.hybrid = new HybridWebView(null/*jsonSerializer*/);

            string html = "<!DOCTYPE html><html lang='ru' dir='ltr' id='html'><head><meta charset='utf-8'></head><body><p>Остров сокровищ</p></body></html>";

            //WebViewSource webViewSource = new HtmlWebViewSource
            //{
            //    Html = "Hello Ilia"/*htmlText*/
            //};


            //this.hybrid.Source = webViewSource;

            

            this.Content = this.hybrid;
        }
    }
}
