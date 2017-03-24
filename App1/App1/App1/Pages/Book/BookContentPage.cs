using System;
using System.Collections.Generic;
using System.Globalization;
using App1.EpubReader.Entities;
using App1.Infrastructure.Buttons;
using Xamarin.Forms;

namespace App1.Pages.Book
{
    public class BookContentPage : ContentPage
    {
        private readonly StackLayout panel;

        public BookContentPage(List<EpubChapter> chapters)
        {
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
            OpenBookChapterButton button = (OpenBookChapterButton) sender;
            BookTextPage bookTextPage = new BookTextPage(button.Chapter);
            this.Navigation.PushAsync(bookTextPage);
        }
    }
}
