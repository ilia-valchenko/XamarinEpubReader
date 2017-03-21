﻿using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace EpubReaderXamarinForms.EpubReader.RefEntities
{
    public class EpubChapterRef
    {
        private readonly EpubTextContentFileRef epubTextContentFileRef;

        public EpubChapterRef(EpubTextContentFileRef epubTextContentFileRef)
        {
            this.epubTextContentFileRef = epubTextContentFileRef;
        }

        public string Title { get; set; }
        public string ContentFileName { get; set; }
        public string Anchor { get; set; }
        public List<EpubChapterRef> SubChapters { get; set; }

        public string ReadHtmlContent()
        {
            return ReadHtmlContentAsync().Result;
        }

        public Task<string> ReadHtmlContentAsync()
        {
            return epubTextContentFileRef.ReadContentAsTextAsync();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Title: {0}, Subchapter count: {1}", Title, SubChapters.Count);
        }
    }
}
