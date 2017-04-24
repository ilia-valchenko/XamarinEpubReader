using System.IO;
using Xamarin.Forms;
using App1.Infrastructure.Controls;

namespace App1.Models
{
    /// <summary>
    /// This page represents a main part of book which is stored in a database.
    /// </summary>
    public class BookInfoViewModel
    {
        /// <summary>
        /// The book's identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The title of a book.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// The author of a book.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// The book's cover image.
        /// </summary>
        public ImageWithLongPressGesture Cover { get; }

        /// <summary>
        /// The path to the book file.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Initialize a new instance of the <see cref="BookInfoViewModel"/>.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <param name="title">The book title.</param>
        /// <param name="author">The author of a book.</param>
        /// <param name="bytesImage">Array of bytes which represent a book cover image.</param>
        /// <param name="filepath">The path to the book file.</param>
        public BookInfoViewModel(string id, string title, string author, byte[] bytesImage, string filepath)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.FilePath = filepath;

            this.Cover = new ImageWithLongPressGesture
            {
                Source = ImageSource.FromStream(() => new MemoryStream(bytesImage)),
            };
        }
    }
}
