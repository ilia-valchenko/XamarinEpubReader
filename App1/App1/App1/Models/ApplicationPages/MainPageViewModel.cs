using System;
using System.Collections.Generic;
using Xamarin.Forms;
using App1.Models.ApplicationPages.BookPages;
using App1.DAL.Interfaces;
using App1.DAL.Entities;
using App1.Infrastructure.Mappers;

namespace App1.Models.ApplicationPages
{
    /// <summary>
    /// The home page of the application.
    /// </summary>
    public class MainPageViewModel : ContentPage
    {
        /// <summary>
        /// The stacklayout panel. 
        /// </summary>
        private readonly StackLayout stackLayout;

        /// <summary>
        /// The grid layout panel.
        /// </summary>
        private readonly Grid gridLayout;

        /// <summary>
        /// The collection of books.
        /// </summary>
        private readonly IList<BookInfoViewModel> books;

        /// <summary>
        /// The book repository.
        /// </summary>
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initialize an instance of the <see cref="MainPageViewModel"/>
        /// </summary>
        /// <param name="books">The collection of books.</param>
        public MainPageViewModel(/*IList<BookViewModel> books*/ IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            IEnumerable<BookEntity> booksEntities = this.bookRepository.GetAll();

            // convert book entity to book info model with automapper
            this.books = new List<BookInfoViewModel>();

            foreach(BookEntity entity in booksEntities)
            {
                BookInfoViewModel bookModel = entity.ToBookInfoModelMapper();
                this.books.Add(bookModel);
            }

            this.stackLayout = new StackLayout();
            this.gridLayout = new Grid();
            this.Padding = new Thickness(20, 20, 20, 20);
            this.Title = "Main page";

            const string backgroundImage = "lightWood.png";
            this.BackgroundImage = backgroundImage;

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
                this.gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            }

            for (int i = 0; i < numberOfBooksPerRow; i++)
            {
                this.gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0, bookNumber = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfBooksPerRow && bookNumber < numberOfBooks; j++, bookNumber++)
                {
                    this.gridLayout.Children.Add(books[bookNumber].BookCoverImage, j, i);
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

            // ------------- add looking for books button ------------------
            this.stackLayout.Children.Add(this.gridLayout);
            Button searchBooksButton = new Button
            {
                Text = "Search books"
            };
            searchBooksButton.Clicked += OnClickSearchBooksButton;
            this.stackLayout.Children.Add(searchBooksButton);
            // ---------------- end of ------------------------------------

            this.Content = new ScrollView
            {
                Content = this.stackLayout,
                Orientation = ScrollOrientation.Vertical
            };
        }

        private void OnClickSearchBooksButton(object sender, EventArgs args)
        {
            // add functionality here
            // add info to database
            DisplayAlert("Message", "Clicked to search books button", "Cancel");
        }
    }
}
