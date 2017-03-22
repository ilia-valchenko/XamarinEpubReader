using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1
{
    public class MainPage : ContentPage
    {
        public MainPage(EpubBook book)
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = $"Title: {book.Title}"
            });

            panel.Children.Add(new Label
            {
                Text = $"Author: {book.Author}",
            });

            foreach (EpubChapter chapter in book.Chapters)
            {
                panel.Children.Add(new Label
                {
                    Text = chapter.Title
                });
            }

            this.Content = panel;
        }
    }
}
