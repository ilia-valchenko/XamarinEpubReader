using System;
using System.Collections.Generic;
using System.Linq;
using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1
{
    public class MainPage : ContentPage
    {
        private readonly StackLayout panel;

        public MainPage(List<EpubBook> books)
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            this.panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            foreach (EpubBook book in books)
            {
                Button openBookButton = new Button
                {
                    Text = $"Title: {book.Title}"
                };

                openBookButton.Clicked += OnClickOpenBook;

                this.panel.Children.Add(openBookButton);
            }

            //panel.Children.Add(new Label
            //{
            //    Text = $"Author: {book.Author}",
            //});

            //// Get all autors

            //if (book.Author != null && book.AuthorList.Count > 0)
            //{
            //    StringBuilder builder = new StringBuilder();
            //    builder.Append("Autors: ");

            //    foreach (string autor in book.AuthorList)
            //    {
            //        builder.Append(autor + "; ");
            //    }

            //    panel.Children.Add(new Label
            //    {
            //        Text = builder.ToString()
            //    });
            //}

            //this.Content = panel;

            this.Content = new ScrollView
            {
                Content = panel,
                Orientation = ScrollOrientation.Vertical
            };

            //this.Content = new WebView
            //{
            //    Source = source
            //};
        }

        private async void OnClickOpenBook(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(BookContentPage(()));
        }
    }
}
