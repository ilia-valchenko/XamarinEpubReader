using System;
using System.Linq;
using System.Collections.Generic;

using App1.DAL.Interfaces;
using App1.DAL.Entities;
using App1.Infrastructure.Mappers;
using App1.EpubReader.Interfaces;
using App1.Infrastructure;
using App1.EpubReader.Entities;

using Xamarin.Forms;

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
        private StackLayout stackLayout;

        /// <summary>
        /// The grid layout panel.
        /// </summary>
        private Grid gridLayout;

        /// <summary>
        /// The collection of books.
        /// </summary>
        private IList<BookInfoViewModel> books;

        /// <summary>
        /// The book repository.
        /// </summary>
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// The number of books per row.
        /// </summary>
        private int numberOfBooksPerRow;

        /// <summary>
        /// The name of the file which represents the backgroung image of the main page.
        /// </summary>
        private string backgroundImageFilename;

        /// <summary>
        /// Initialize an instance of the <see cref="MainPageViewModel"/>
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public MainPageViewModel(IBookRepository bookRepository)
        {
            //this.BindingContext = this;

            this.bookRepository = bookRepository;
            this.books = this.bookRepository.GetAll().ToListOfBookInfoViewModel();

            this.stackLayout = new StackLayout();
            this.gridLayout = new Grid();
            this.Padding = new Thickness(20, 20, 20, 20);
            this.Title = "Japet Reader";

            // Take it from the database.
            // Delete it from the class fields.
            backgroundImageFilename = "lightWood.png";
            this.BackgroundImage = backgroundImageFilename;
            // Take it from config or database.
            // Delete it from the class fields.
            numberOfBooksPerRow = 3;

            this.UpdateBookLibrary(this.books);

            this.stackLayout.Children.Add(this.gridLayout);
            Button searchBooksButton = new Button { Text = "Search books" };
            searchBooksButton.Clicked += OnClickSearchBooksButton;
            this.stackLayout.Children.Add(searchBooksButton);

            Button redButton = new Button
            {
                Text = "Delete All",
                TextColor = Color.White,
                BackgroundColor = Color.Red,
            };

            redButton.Clicked += async (object sender, EventArgs args) => 
            {
                bool answer = await DisplayAlert("Question", "Do you really want to delete all books from the database?", "Yes", "No");

                if (answer)
                {
                    this.bookRepository.DeleteAll();
                    this.gridLayout.Children.Clear();
                }
            };

            this.stackLayout.Children.Add(redButton);

            this.Content = new ScrollView
            {
                Content = this.stackLayout,
                Orientation = ScrollOrientation.Vertical
            };
        }

        /// <summary>
        /// This method is looking for a books, adds books to the main page if they are not contains in the database,
        /// deletes books if they don't exist on the user's device. It helps to hold actual data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">An object that contains the event data.</param>
        private void OnClickSearchBooksButton(object sender, EventArgs args)
        {
            IFiler filer = DependencyService.Get<IFiler>();
            IEnumerable<string> filesPath = filer.GetFilesPaths(FileExtension.EPUB);
            IEnumerable<EpubBook> epubBooks = filesPath.Select(f => EpubReader.EpubReader.ReadBook(f));
            this.books = new List<BookInfoViewModel>();

            // Try to read not all book information.
            // I need to read only a necessary information e.g. Title, Author, Cover.
            foreach (EpubBook epubBook in epubBooks)
            {
                // If the book entity does not exist.
                if (this.books.All(b => b.FilePath != epubBook.FilePath))
                {
                    BookEntity entity = new BookEntity
                    {
                        Title = epubBook.Title,
                        Author = epubBook.Author,
                        // It should be changed.
                        // An image might be missed.
                        Cover = epubBook.Content.Images.FirstOrDefault().Value.Content,
                        FilePath = epubBook.FilePath
                    };

                    int statusCode = this.bookRepository.Add(entity);

                    // 0 is SQLITE_OK 
                    // But returns 1 and entity is successfully saved into database.
                    if (statusCode == 1)
                    {
                        BookInfoViewModel model = entity.ToBookInfoModelMapper();
                        this.books.Add(model);
                    }
                }
            }

            this.UpdateBookLibrary(this.books);
        }

        /// <summary>
        /// This method updates user's book library on the main page.
        /// </summary>
        /// <param name="books">The actual collection of a book info view models.</param>
        private void UpdateBookLibrary(IList<BookInfoViewModel> books)
        {
            this.gridLayout.RowDefinitions.Clear();
            this.gridLayout.ColumnDefinitions.Clear();

            //this.panel = new Grid
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    ColumnSpacing = 5,
            //    RowSpacing = 5
            //};

            int numberOfBooks = this.books.Count;
            int numberOfRows = (int)Math.Ceiling((double)numberOfBooks / numberOfBooksPerRow);

            // Configure the grid layout.
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
                    this.gridLayout.Children.Add(books[bookNumber].Cover, j, i);
                }
            }

            // Set the tap recognizer.
            foreach (BookInfoViewModel book in books)
            {
                TapGestureRecognizer bookCoverImageTap = new TapGestureRecognizer();
                bookCoverImageTap.Tapped += this.OnClickBookCoverImage;
                book.Cover.GestureRecognizers.Add(bookCoverImageTap);
            }
        }

        /// <summary>
        /// This method opens a book when the book's cover image is clicked. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">An object that contains the event data.</param>
        private void OnClickBookCoverImage(object sender, EventArgs args)
        {
            CarouselPage carouselPage = new CarouselPage { Title = "Go to Main page" };

            // Open the full book here.

            //foreach (BookPage bookPage in book.Pages)
            //{
            //    carouselPage.Children.Add(bookPage);
            //}

            this.Navigation.PushAsync(carouselPage);
        }
    }
}
