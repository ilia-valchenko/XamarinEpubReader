using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using App1.Models.ApplicationPages.BookPages;
using System;
using System.IO;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Controls;
//using XLabs.Serialization.JsonNET;

namespace App1.Models.ApplicationPages
{
    public class TestHybridWebViewPage : BookPage
    {
        private readonly HybridWebView hybrid;
        //private readonly CustomHybridWebView customHybrid;
        //private readonly App1.Infrastructure.Controls.HybridWebView hybrid;

        /// <summary>
        /// Initialize a new instance of the <see cref="TestHybridWebViewPage"/> class.
        /// </summary>
        /// <param name="chapter">The epub book chapter.</param>
        public TestHybridWebViewPage(EpubChapter chapter)
        {
            this.Title = "HybridWebView page";
            //string htmlText = chapter.HtmlContent.Replace(@"\", string.Empty);
            ////JsonSerializer jsonSerializer = new JsonSerializer();
            //this.hybrid = new HybridWebView(null/*jsonSerializer*/);

            //string testHtml = "<!DOCTYPE html><html><head><meta charset='utf-8'></head><body><p>Hello World (Привет мир)</p></body></html>";

            #region Get stream from local html file

            /*IFiler filer = DependencyService.Get<IFiler>();

            string filename = "hello.html";
            Stream stream;
            string customHtml = null;
            WebViewSource webViewSource = null;

            stream = filer.GetResourceFileStream(filename);
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                customHtml = reader.ReadToEnd();
                customHtml.Replace(@"\", string.Empty);
            }

            if (string.IsNullOrEmpty(customHtml))
            {
                DisplayAlert("Alert", "Custom html is null or empty!", "Cancel");
            }
            else
            {
                webViewSource = new HtmlWebViewSource
                {
                    Html = "Hello World (Привет мир)" // customHtml
                };

                try
                {
                    this.customHybrid.Source = webViewSource;
                    this.Content = this.customHybrid;
                }
                catch (Exception e)
                {
                    throw e;
                }
            } */

            #endregion
        }
    }
}
