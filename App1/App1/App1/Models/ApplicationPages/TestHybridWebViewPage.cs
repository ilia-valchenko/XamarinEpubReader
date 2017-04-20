using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.EpubReader.Entities;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace App1.Models.ApplicationPages
{
    public class TestHybridWebViewPage : ContentPage
    {
        private readonly HybridWebView hybrid;

        public TestHybridWebViewPage(EpubChapter chapter)
        {
            string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);

            JsonSerializer jsonSerializer = new JsonSerializer();
            this.hybrid = new HybridWebView(jsonSerializer);

            WebViewSource webViewSource = new HtmlWebViewSource
            {
                Html = htmlText
            };

            this.hybrid.Source = webViewSource;

            this.Content = this.hybrid;
        }
    }
}
