using System;
using System.Collections.Generic;
using System.Globalization;

using App1.EpubReader.Entities;
using App1.Infrastructure.Buttons;

using Xamarin.Forms;

namespace App1.Models.ApplicationPages.BookPages
{
    /// <summary>
    /// This class represents a book page with contents.
    /// </summary>
    public class BookContentPageViewModel : BookPage
    {
        /// <summary>
        /// The stack layout panel.
        /// </summary>
        private readonly StackLayout panel;

        /// <summary>
        /// Initialize a new instance of the <see cref="BookContentPageViewModel"/>.
        /// </summary>
        /// <param name="chapters"></param>
        public BookContentPageViewModel(List<EpubChapter> chapters)
        {
            this.Title = "Content page";
            this.panel = new StackLayout();

            foreach (EpubChapter chapter in chapters)
            {
                this.WriteChapter(chapter, panel);
            }

            this.Content = new ScrollView
            {
                Content = panel
            };
        }

        private void WriteChapter(EpubChapter epubChapter, Layout<View> layout)
        {
            if (epubChapter.SubChapters != null && epubChapter.SubChapters.Count > 0)
            {
                OpenBookChapterButton button = new OpenBookChapterButton(epubChapter)
                {
                    Text = string.Format(CultureInfo.InvariantCulture, epubChapter.Title)
                };

                button.Clicked += OnClickOpenBookChapterButton;

                layout.Children.Add(button);

                foreach (EpubChapter chapter in epubChapter.SubChapters)
                {
                    WriteChapter(chapter, layout);
                }
            }
            else
            {
                OpenBookChapterButton button = new OpenBookChapterButton(epubChapter)
                {
                    Text = string.Format(CultureInfo.InvariantCulture, epubChapter.Title)
                };

                button.Clicked += OnClickOpenBookChapterButton;

                layout.Children.Add(button);
            }
        }

        private void OnClickOpenBookChapterButton(object sender, EventArgs args)
        {
            // Change the current page.
            // User selects a chapter to read. 
            // Navigate to page from the chapter is started.
        }
    }
}
