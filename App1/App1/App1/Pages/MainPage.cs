using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using App1.EpubReader.Entities;
using App1.EpubReader.Schema.Opf;
using App1.Infrastructure;
using App1.Infrastructure.Buttons;
using Xamarin.Forms;
using App1.Pages.Book;
using App1.Pages.Error;

namespace App1.Pages
{
    /// <summary>
    /// The home page of the application.
    /// </summary>
    public class MainPage : ContentPage
    {
        private readonly StackLayout panel;

        /// <summary>
        /// The collection of books.
        /// </summary>
        private IEnumerable<EpubBook> books;

        /// <summary>
        /// Initialize an instance of the <see cref="MainPage"/>
        /// </summary>
        /// <param name="books">The collection of books.</param>
        public MainPage(IEnumerable<EpubBook> books)
        {
            this.Title = "Main page";
            this.books = books;
            this.Padding = new Thickness(20, 20, 20, 20);

            this.panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            foreach (EpubBook book in this.books)
            {
                byte[] byteImage = book.Content.Images.FirstOrDefault().Value.Content;

                Image img = new Image();
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(byteImage));
                img.Source = imageSource;

                this.panel.Children.Add(img);

                OpenBookButton openBookButton = new OpenBookButton(book)
                {
                    Text = $"Title: {book.Title}"
                };

                openBookButton.Clicked += OnClickOpenBookButton;
                this.panel.Children.Add(openBookButton);
            }

            this.Content = new ScrollView
            {
                Content = this.panel,
                Orientation = ScrollOrientation.Vertical
            };
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
    }
}
