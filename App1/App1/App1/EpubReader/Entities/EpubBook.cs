﻿using System.Collections.Generic;
using Xamarin.Forms;

//using System.Drawing;

namespace App1.EpubReader.Entities
{
    public class EpubBook
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> AuthorList { get; set; }
        public EpubSchema Schema { get; set; }
        public EpubContent Content { get; set; }
        public Image CoverImage { get; set; }
        public List<EpubChapter> Chapters { get; set; }
    }
}
