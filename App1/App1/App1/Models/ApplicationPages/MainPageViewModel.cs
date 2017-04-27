using App1.DAL.Entities;
using App1.DAL.Interfaces;
using App1.EpubReader.Entities;
using App1.Infrastructure;
using App1.Infrastructure.Interfaces;
using App1.Infrastructure.Mappers;
using App1.Models.ApplicationPages.BookPages;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// A collection of book entities.
        /// </summary>
        private readonly IList<BookEntity> bookEntities;

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
            this.stackLayout = new StackLayout();
            this.gridLayout = new Grid();
            this.Padding = new Thickness(20, 20, 20, 20);
            this.Title = "Japet Reader";
            this.bookRepository = bookRepository;
            this.bookEntities = this.bookRepository.GetAll().ToList();
            this.books = bookEntities.ToListOfBookInfoViewModel();

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

            #region Test RED BUTTON - Delete all

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
             
            #endregion

            #region Test device measurement

            Button showDeviceMeasurementButton = new Button
            {
                Text = "Device measurement"
            };

            showDeviceMeasurementButton.Clicked += (sender, args) =>
            {
                TestPageDeviceMeasurementViewModel measurementPage = new TestPageDeviceMeasurementViewModel();
                this.Navigation.PushAsync(measurementPage);
            };

            this.stackLayout.Children.Add(showDeviceMeasurementButton);

            #endregion

            Button test = new Button
            {
                Text = "Show html from assert"
            };

            test.Clicked += (sender, args) =>
            {
                BookTextPageViewModel page = new BookTextPageViewModel(null);
                this.Navigation.PushAsync(page);
            };

            this.stackLayout.Children.Add(test);

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
            IEnumerable<string> pathsOfFoundFiles = filer.GetFilesPaths(FileExtension.EPUB).ToList();
            IEnumerable<EpubBook> epubBooks = pathsOfFoundFiles.Select(f => EpubReader.EpubReader.ReadBook(f));
            List<string> pathsOfExistingFiles = this.bookEntities.Select(entity => entity.FilePath).ToList();

            // Try to read not all book information.
            // I need to read only a necessary information e.g. Title, Author, Cover.
            foreach (EpubBook epubBook in epubBooks)
            {
                // If the book entity does not exist.
                // Add a new book info to the main page.
                if (pathsOfExistingFiles.Contains(epubBook.FilePath) == false)
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
                        this.bookEntities.Add(entity);
                        BookInfoViewModel model = entity.ToBookInfoModelMapper();
                        this.books.Add(model);
                    }
                }
            }

            // Delete book info models and book entities which do not exist yet.
            foreach (var pathOfExistingFile in pathsOfExistingFiles)
            {
                if (pathsOfFoundFiles.Contains(pathOfExistingFile) == false)
                {
                    // Delete entity.
                    BookEntity deletedBookEntity = this.bookEntities.FirstOrDefault(e => e.FilePath == pathOfExistingFile);
                    this.bookRepository.DeleteById(deletedBookEntity.Id);
                    this.bookEntities.Remove(deletedBookEntity);

                    // Delete book info view model.
                    BookInfoViewModel deletedBookInfoViewModel = this.books.FirstOrDefault(m => m.FilePath == pathOfExistingFile);
                    this.books.Remove(deletedBookInfoViewModel);
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

            if (books != null && books.Count > 0)
            {
                //this.panel = new Grid
                //{
                //    VerticalOptions = LayoutOptions.FillAndExpand,
                //    HorizontalOptions = LayoutOptions.FillAndExpand,
                //    ColumnSpacing = 5,
                //    RowSpacing = 5
                //};

                int numberOfBooks = books.Count;
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

                // Set click and long press event handlers
                foreach (BookInfoViewModel book in books)
                {
                    
                    book.Cover.longPressAction = () => this.OnLongPressBookCoverImage(book);
                    book.Cover.click = () => this.OnClickBookCoverImage(book);
                }
            }
        }

        /// <summary>
        /// This method represents a handle for the long press action.
        /// </summary>
        /// <param name="bookInfo">The book info view model.</param>
        private async void OnLongPressBookCoverImage(BookInfoViewModel bookInfo)
        {
            string action = await DisplayActionSheet(null, "Cancel", null, "Open", "Open in Hybrid", "Delete");

            switch(action)
            {
                case ("Open"):
                    this.OnClickBookCoverImage(bookInfo);
                    break;

                case ("Open in Hybrid"):
                    await DisplayAlert("Alert", "This part was deleted.", "Cancel");
                    break;

                case ("Delete"):
                    this.bookRepository.DeleteById(bookInfo.Id);
                    break;
            }
        }

        /// <summary>
        /// This method opens a book when the book's cover image is clicked. 
        /// </summary>
        /// <param name="bookInfo">The book info view model.</param>
        private async void OnClickBookCoverImage(BookInfoViewModel bookInfo)
        {
            if (bookInfo == null)
            {
                await DisplayAlert("Attention", "Something went wrong. I can't open this book. Please check does it exist yet?", "Cancel");
            }
            else
            {
                if (string.IsNullOrEmpty(bookInfo.FilePath))
                {
                    await DisplayAlert("Attention", "Something went wrong. The path to the book file is empty or it is invalid.", "Cancel");
                }
                else
                {
                    EpubBook epubBook = await EpubReader.EpubReader.ReadBookAsync(bookInfo.FilePath);
                    BookTextPageViewModel page = new BookTextPageViewModel(epubBook) { Title = "Go to Main page" };

                    await this.Navigation.PushAsync(page);
                }
            }
        }
    }
}
