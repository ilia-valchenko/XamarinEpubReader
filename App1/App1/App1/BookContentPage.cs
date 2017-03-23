using System;
using System.Collections.Generic;
using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1
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
                layout.Children.Add(this.CreateGoToChapterButton(epubChapter.Title));

                foreach (EpubChapter chapter in epubChapter.SubChapters)
                {
                    WriteChapter(chapter, layout);
                }
            }
            else
            {
                layout.Children.Add(this.CreateGoToChapterButton(epubChapter.Title));
            }
        }

        private Button CreateGoToChapterButton(string text)
        {
            Button goToChapterButton = new Button
            {
                Text = text
            };

            goToChapterButton.Clicked += OnClickGoToChapterButton;

            return goToChapterButton;
        }

        private void OnClickGoToChapterButton(object sender, EventArgs args)
        {
            
        }
    }
}
