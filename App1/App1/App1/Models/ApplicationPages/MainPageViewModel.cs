using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        private readonly StackLayout stackLayout;

        /// <summary>
        /// The grid layout panel.
        /// </summary>
        private Grid gridLayout;

        /// <summary>
        /// The collection of books.
        /// </summary>
        private readonly IList<BookInfoViewModel> books;

        // remove
        ///// <summary>
        ///// The collection of books.
        ///// </summary>
        //private readonly ObservableCollection<BookInfoViewModel> books;

        /// <summary>
        /// The book repository.
        /// </summary>
        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initialize an instance of the <see cref="MainPageViewModel"/>
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        public MainPageViewModel(IBookRepository bookRepository)
        {
            // remove
            // test
            //this.BindingContext = this;

            this.bookRepository = bookRepository;
            this.books = this.bookRepository.GetAll().ToListOfBookInfoViewModel();

            // remove
            //this.books = new ObservableCollection<BookInfoViewModel>();
            //IEnumerable<BookEntity> bookEntities = this.bookRepository.GetAll();
            //foreach (BookEntity entity in bookEntities)
            //{
            //    BookInfoViewModel model = entity.ToBookInfoModelMapper();
            //    this.books.Add(model);
            //}

            this.stackLayout = new StackLayout();
            this.gridLayout = new Grid();
            this.Padding = new Thickness(20, 20, 20, 20);
            this.Title = "Main page";

            // take it from the database
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
                    this.gridLayout.Children.Add(books[bookNumber].Cover, j, i);
                }
            }

            // set tap recognizer 
            foreach (BookInfoViewModel book in this.books)
            {
                TapGestureRecognizer bookCoverImageTap = new TapGestureRecognizer();
                bookCoverImageTap.Tapped += (object sender, EventArgs e) =>
                {
                    //CarouselPage carouselPage = new CarouselPage
                    //{
                    //    Title = "Go to Main page"
                    //};

                    //foreach (BookPage bookPage in book.Pages)
                    //{
                    //    carouselPage.Children.Add(bookPage);
                    //}

                    //this.Navigation.PushAsync(carouselPage);
                };

                book.Cover.GestureRecognizers.Add(bookCoverImageTap);
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
            IFiler filer = DependencyService.Get<IFiler>();
            IEnumerable<string> filesPath = filer.GetFilesPaths(FileExtension.EPUB);
            IEnumerable<EpubBook> epubBooks = filesPath.Select(f => EpubReader.EpubReader.ReadBook(f));

            this.gridLayout = new Grid();

            foreach(EpubBook epubBook in epubBooks)
            {
                if(this.books.All(b => b.FilePath != epubBook.FilePath))
                {
                    BookEntity entity = new BookEntity
                    {
                        Title = epubBook.Title,
                        Author = epubBook.Author,
                        // change it
                        // the image might be missed
                        Cover = epubBook.Content.Images.FirstOrDefault().Value.Content,
                        FilePath = epubBook.FilePath
                    };

                    BookInfoViewModel model = entity.ToBookInfoModelMapper();

                    this.books.Add(model);
                }
            }

            const int numberOfBooksPerRow = 3;
            int numberOfBooks = this.books.Count;
            int numberOfRows = (int)Math.Ceiling((double)numberOfBooks / numberOfBooksPerRow);

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
                    this.gridLayout.Children.Add(books[bookNumber].Cover, j, i);
                }
            }

            //// Try to read not all book information.
            //// I need to read only necessary information.
            //foreach (EpubBook epubBook in epubBooks)
            //{
            //    // If the book entity does not exist.
            //    if (this.books.All(b => b.FilePath != epubBook.FilePath))
            //    {
            //        BookEntity entity = new BookEntity
            //        {
            //            Title = epubBook.Title,
            //            Author = epubBook.Author,
            //            // change it
            //            // the image might be missed
            //            Cover = epubBook.Content.Images.FirstOrDefault().Value.Content,
            //            FilePath = epubBook.FilePath
            //        };

            //        int statusCode = this.bookRepository.Add(entity);

            //        // 0 is SQLITE_OK 
            //        if (statusCode == 0)
            //        {
            //            BookInfoViewModel model = entity.ToBookInfoModelMapper();
            //            this.books.Add(model);

            //            // test refresh main page
            //            Label label = new Label
            //            {
            //                 Text = "New book added",
            //                 TextColor = Color.Maroon
            //            };

            //            this.stackLayout.Children.Add(label);
            //        }
            //    }
        
        }
    }
}
