using Xamarin.Forms;

namespace EpubReaderXamarinForms
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            //panel.Children.Add(new Label
            //{
            //    Text = $"Title: {book.Title}"
            //});

            //panel.Children.Add(new Label
            //{
            //    Text = $"Author: {book.Author}",
            //});

            //foreach (string chapterName in book.Chapters)
            //{
            //    panel.Children.Add(new Label
            //    {
            //        Text = chapterName
            //    });
            //}

            this.Content = panel;
        }
    }
}
