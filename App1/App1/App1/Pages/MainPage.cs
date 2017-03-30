using System;
using System.Collections.Generic;
using System.Linq;
using App1.EpubReader.Entities;
using App1.Infrastructure;
using App1.Infrastructure.Buttons;
using Xamarin.Forms;
using App1.Pages.Book;
using App1.Pages.Error;

namespace App1.Pages
{
    public class MainPage : ContentPage
    {
        private readonly StackLayout panel;
        private IEnumerable<EpubBook> books;

        public MainPage(IEnumerable<EpubBook> books)
        {
            this.books = books;
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
                ImageSource imageSource;

                try
                {
                    imageSource = book.CoverImage.Source;
                }
                catch (Exception exception)
                {
                    throw exception;
                }

                ImageCell imageCell = new ImageCell
                {
                    ImageSource = imageSource
                };

                OpenBookButton openBookButton = new OpenBookButton(book)
                {
                    Text = $"Title: {book.Title}"
                };

                openBookButton.Clicked += OnClickOpenBookButton;
                this.panel.Children.Add(openBookButton);
            }

            Button backButton = new Button
            {
                Text = "Go Back"
            };
            backButton.Clicked += OnBackButtonClick;
            panel.Children.Add(backButton);

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

        private async void OnClickOpenBookButton(object sender, EventArgs e)
        {
            OpenBookButton button = (OpenBookButton) sender;
            List<EpubChapter> chapters;

            try
            {
                chapters = button.Book.Chapters;
                BookContentPage bookContentPage = new BookContentPage(button.Book.Chapters);
                await this.Navigation.PushAsync(bookContentPage);
            }
            catch (NullReferenceException nullReferenceException)
            {
                // log
                ErrorPage errorPage = new ErrorPage(nullReferenceException);
                await this.Navigation.PushAsync(errorPage);
                // rethrow 
            }
            catch (Exception exc)
            {
                // log
                ErrorPage errorPage = new ErrorPage(exc);
                await this.Navigation.PushAsync(errorPage);
                // rethrow
            }
        }

        private async void OnBackButtonClick(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}
