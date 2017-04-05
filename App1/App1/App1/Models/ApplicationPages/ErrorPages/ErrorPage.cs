using System;
using System.Globalization;
using Xamarin.Forms;

namespace App1.Models.ApplicationPages.ErrorPages
{
    public class ErrorPage : ContentPage
    {
        private readonly string errorMessage;
        private readonly string stackTrace;
        private readonly StackLayout panel;

        public ErrorPage(Exception exception)
        {
            this.errorMessage = exception.Message;
            this.stackTrace = exception.StackTrace;
            this.panel = new StackLayout();

            panel.Children.Add(new Label
            {
                Text = string.Format(CultureInfo.InvariantCulture, $"Error: {this.errorMessage}")
            });

            panel.Children.Add(new Label
            {
                Text = string.Format(CultureInfo.InvariantCulture, $"StackTrace: {this.stackTrace}")
            });
        }
    }
}
