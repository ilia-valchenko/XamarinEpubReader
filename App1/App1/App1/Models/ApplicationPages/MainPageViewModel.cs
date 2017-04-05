using System;
using System.Collections.Generic;
using App1.EpubReader.Entities;
using Xamarin.Forms;
using App1.Models.ApplicationPages.BookPages;

namespace App1.Models.ApplicationPages
{
    /// <summary>
    /// The home page of the application.
    /// </summary>
    public class MainPageViewModel : ContentPage
    {
        private readonly StackLayout panel;

        /// <summary>
        /// The collection of books.
        /// </summary>
        private IEnumerable<EpubBook> books;

        /// <summary>
        /// Initialize an instance of the <see cref="MainPageViewModel"/>
        /// </summary>
        /// <param name="books">The collection of books.</param>
        public MainPageViewModel(IEnumerable<EpubBook> books)
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

            foreach (EpubBook epubBook in this.books)
            {
                BookViewModel bookViewModel = new BookViewModel(epubBook);

                var bookCoverImageTap = new TapGestureRecognizer();
                bookCoverImageTap.Tapped += (object sender, EventArgs e) =>
                {
                    CarouselPage carouselPage = new CarouselPage
                    {
                        Title = "Main page"
                    };

                    foreach(BookPage bookPage in bookViewModel.Pages)
                    {
                        carouselPage.Children.Add(bookPage);
                    }

                    this.Navigation.PushAsync(carouselPage);
                };

                bookViewModel.BookCoverImage.GestureRecognizers.Add(bookCoverImageTap);

                this.panel.Children.Add(bookViewModel.BookCoverImage);
            }

            this.Content = new ScrollView
            {
                Content = this.panel,
                Orientation = ScrollOrientation.Vertical
            };
        }
    }
}
