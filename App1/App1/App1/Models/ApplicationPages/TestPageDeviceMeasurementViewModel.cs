using Xamarin.Forms;

namespace App1.Models.ApplicationPages
{
    public class TestPageDeviceMeasurementViewModel : ContentPage
    {
        public TestPageDeviceMeasurementViewModel()
        {
            double height = Application.Current.MainPage.Height;
            double width = Application.Current.MainPage.Width;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Page width: " + width },
                    new Label { Text = "Page height: " + height }
                }
            };
        }
    }
}
