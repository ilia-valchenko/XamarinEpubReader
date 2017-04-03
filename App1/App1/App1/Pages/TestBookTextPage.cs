using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1.Pages
{
    public class TestBookTextPage : ContentPage
    {
        private readonly StackLayout panel;

        public TestBookTextPage(string htmlString)
        {
            this.Title = "Short text page";
            panel = new StackLayout();

            string htmlText = htmlString.Replace(@"\", string.Empty);

            HtmlWebViewSource source = new HtmlWebViewSource
            {
                Html = htmlText
            };

            this.Content = new WebView
            {
                Source = source,
            };
        }
    }
}
