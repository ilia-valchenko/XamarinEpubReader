using App1.Infrastructure;
using SkiaSharp;
using Xamarin.Forms;

namespace App1.Models.ApplicationPages
{
    public class TestPageDeviceMeasurementViewModel : ContentPage
    {
        public TestPageDeviceMeasurementViewModel()
        {
            double height = Application.Current.MainPage.Height;
            double width = Application.Current.MainPage.Width;

            string text = "The policeman";
            ITextMeter textMeter = DependencyService.Get<ITextMeter>();

            Content = new StackLayout
            {
                Children = {
                    new Label {Text = text },
                    new Label { Text = textMeter.MeasureText(text).ToString() },
                    new Label { Text = "Page width: " + width },
                    new Label { Text = "Page height: " + height }
                }
            };
        }
    }
}
