using Xamarin.Forms;

namespace App1.Pages
{
    public class TestPage : ContentPage
    {
        public TestPage()
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
