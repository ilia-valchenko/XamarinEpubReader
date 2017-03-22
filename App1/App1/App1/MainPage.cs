using System.Linq;
using System.Text;
using App1.EpubReader.Entities;
using Xamarin.Forms;

namespace App1
{
    public class MainPage : ContentPage
    {
        public MainPage(EpubBook book)
        {
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            panel.Children.Add(new Label
            {
                Text = $"Title: {book.Title}"
            });

            panel.Children.Add(new Label
            {
                Text = $"Author: {book.Author}",
            });

            // Get all autors
            if (book.Author != null && book.AuthorList.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Autors: ");

                foreach (string autor in book.AuthorList)
                {
                    builder.Append(autor + "; ");
                }

                panel.Children.Add(new Label
                {
                    Text = builder.ToString()
                });
            }

            foreach (EpubChapter chapter in book.Chapters)
            {
                //panel.Children.Add(new Label
                //{
                //    Text = chapter.Title,
                    
                //});

                WriteChapter(chapter, panel);
            }

            //this.Content = panel;

            byte[] b = new byte[5];
            book.Chapters.First().SubChapters.First()

            panel.Children.Add(new );

            this.Content = new ScrollView
            {
                Content = panel,
                Orientation = ScrollOrientation.Vertical
            };
        }

        private void WriteChapter(EpubChapter epubChapter, Layout<View> layout)
        {
            if (epubChapter.SubChapters != null && epubChapter.SubChapters.Count > 0)
            {
                layout.Children.Add(new Label
                {
                    Text = epubChapter.Title
                });

                foreach (EpubChapter chapter in epubChapter.SubChapters)
                {
                    WriteChapter(chapter, layout);
                }
            }
            else
            {
                layout.Children.Add(new Label
                {
                    Text = epubChapter.Title
                });
            }
        }
    }
}
