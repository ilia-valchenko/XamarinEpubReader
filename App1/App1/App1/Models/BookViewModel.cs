using System.Collections.Generic;
using System.Linq;
using System.IO;

using App1.EpubReader.Entities;
using App1.Models.ApplicationPages.BookPages;

using Xamarin.Forms;

namespace App1.Models
{
    public class BookViewModel
    {
        private readonly Image bookCoverImage;
        private readonly IList<BookPage> pages;
        
        public IList<BookPage> Pages
        {
            get
            {
                return this.pages;
            }
        }
        
        public int NumberOfPages {
            get {
                return this.pages.Count;
            }
        }

        public Image BookCoverImage
        {
            get
            {
                return this.bookCoverImage;
            }
        }

        /// <summary>
        /// Initializes the instance of <see cref="BookViewModel"/>
        /// </summary>
        public BookViewModel(EpubBook epubBook)
        {
            // ------------------ Initialize book image cover --------------------

            // The picture may be missing. 
            byte[] byteImage = epubBook.Content.Images.FirstOrDefault().Value.Content;

            Image bookCoverImage = new Image
            {
                Source = ImageSource.FromStream(() => new MemoryStream(byteImage))
            };

            this.bookCoverImage = bookCoverImage;

            // ---------------------- Initialize book Pages ----------------------- 

            this.pages = new List<BookPage>();

            // set book cover image as the first page of a book

            BookContentPageViewModel contentPage = new BookContentPageViewModel(epubBook.Chapters);
            this.pages.Add(contentPage);

            foreach(EpubChapter chapter in epubBook.Chapters)
            {
                WriteChapter(chapter, this.pages);
            }
        }

        private void WriteChapter(EpubChapter epubChapter, IList<BookPage> pages)
        {
            if (epubChapter.SubChapters != null && epubChapter.SubChapters.Count > 0)
            {
                BookTextPageViewModel bookTextPage = new BookTextPageViewModel(epubChapter);

                foreach (EpubChapter chapter in epubChapter.SubChapters)
                {
                    WriteChapter(chapter, pages);
                }
            }
            else
            {
                BookTextPageViewModel bookTextPage = new BookTextPageViewModel(epubChapter);
                pages.Add(bookTextPage);
            }
        }
    }
}
