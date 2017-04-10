using System.IO;
using Xamarin.Forms;

namespace App1.Models
{
    public class BookInfoViewModel
    {
        public string Title { get; }

        public string Author { get; }

        /// <summary>
        /// The book's cover image.
        /// </summary>
        public Image Cover { get; }

        public string FilePath { get; }

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
