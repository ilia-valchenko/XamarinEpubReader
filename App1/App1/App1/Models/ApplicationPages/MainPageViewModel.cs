using System;
using System.Collections.Generic;
using Xamarin.Forms;
using App1.Models.ApplicationPages.BookPages;

namespace App1.Models.ApplicationPages
{
    /// <summary>
    /// The home page of the application.
    /// </summary>
    public class MainPageViewModel : ContentPage
    {
        /// <summary>
        /// The grid layout panel.
        /// </summary>
        private readonly Grid panel;

        /// <summary>
        /// The collection of books.
        /// </summary>
        private readonly IList<BookViewModel> books;

        /// <summary>
        /// Initialize an instance of the <see cref="MainPageViewModel"/>
        /// </summary>
        /// <param name="books">The collection of books.</param>
        public MainPageViewModel(IList<BookViewModel> books)
        {
            this.books = books;
            this.panel = new Grid();
            this.Padding = new Thickness(20, 20, 20, 20);
            this.Title = "Main page";
            
            // take it from config or database
            const int numberOfBooksPerRow = 3;
            int numberOfBooks = this.books.Count;
            int numberOfRows = (int)Math.Ceiling((double)numberOfBooks / numberOfBooksPerRow);

            //this.panel = new Grid
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    ColumnSpacing = 5,
            //    RowSpacing = 5
            //};

            // configure grid layout
            for (int i = 0; i < numberOfRows; i++)
            {
                this.panel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            }

            for (int i = 0; i < numberOfBooksPerRow; i++)
            {
                this.panel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0, bookNumber = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfBooksPerRow && bookNumber < numberOfBooks; j++, bookNumber++)
                {
                    this.panel.Children.Add(books[bookNumber].BookCoverImage, j, i);
                }
            }

            // set tap recognizer 
            foreach (BookViewModel book in this.books)
            {
                TapGestureRecognizer bookCoverImageTap = new TapGestureRecognizer();
                bookCoverImageTap.Tapped += (object sender, EventArgs e) =>
                {
                    CarouselPage carouselPage = new CarouselPage
                    {
                        Title = "Go to Main page"
                    };

                    foreach (BookPage bookPage in book.Pages)
                    {
                        carouselPage.Children.Add(bookPage);
                    }

                    this.Navigation.PushAsync(carouselPage);
                };

                book.BookCoverImage.GestureRecognizers.Add(bookCoverImageTap);
            }

            this.Content = new ScrollView
            {
                Content = this.panel,
                Orientation = ScrollOrientation.Vertical
            };
        }
    }
}
