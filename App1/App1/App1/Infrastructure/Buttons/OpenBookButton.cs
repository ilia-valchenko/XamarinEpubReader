using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1.Infrastructure.Buttons
{
    class OpenBookButton : Button
    {
        private readonly EpubBook book;

        public EpubBook Book
        {
            get
            {
                return this.book;
            }
        }

        public OpenBookButton(EpubBook book)
        {
            this.book = book;
        }
    }
}
