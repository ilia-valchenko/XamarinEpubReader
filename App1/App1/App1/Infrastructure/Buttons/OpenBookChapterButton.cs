using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1.Infrastructure.Buttons
{
    public class OpenBookChapterButton : Button
    {
        private readonly EpubChapter chapter;

        public EpubChapter Chapter
        {
            get
            {
                return this.chapter;
            }
        }

        public OpenBookChapterButton(EpubChapter chapter)
        {
            this.chapter = chapter;
        }
    }
}
