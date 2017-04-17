using Xamarin.Forms;

namespace App1.Models.ApplicationPages.BookPages
{
    /// <summary>
    /// This class represents the first page of a book which contains a cover image of a book.
    /// </summary>
    public class BookCoverPageViewModel : BookPage
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="BookCoverPageViewModel"/> class.
        /// </summary>
        public BookCoverPageViewModel(Image bookCoverImage)
        {
            this.Content = bookCoverImage;
        }
    }
}
