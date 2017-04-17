﻿using System.IO;
using Xamarin.Forms;

namespace App1.Models
{
    /// <summary>
    /// This page represents a main part of book which is stored in a database.
    /// </summary>
    public class BookInfoViewModel
    {
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
        public Image Cover { get; }

        /// <summary>
        /// The path to the book file.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Initialize a new instance of the <see cref="BookInfoViewModel"/>.
        /// </summary>
        /// <param name="title">The book title.</param>
        /// <param name="author">The author of a book.</param>
        /// <param name="bytesImage">Array of bytes which represent a book cover image.</param>
        /// <param name="filepath">The path to the book file.</param>
        public BookInfoViewModel(string title, string author, byte[] bytesImage, string filepath)
        {
            this.Title = title;
            this.Author = author;
            this.FilePath = filepath;

            this.Cover = new Image
            {
                Source = ImageSource.FromStream(() => new MemoryStream(bytesImage))
            };
        }
    }
}
