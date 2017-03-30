using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.EpubReader.Entities;
using App1.EpubReader.Interfaces;
using App1.EpubReader.Readers;
using Xamarin.Forms;

namespace App1.EpubReader.RefEntities
{
    public class EpubBookRef : IDisposable
    {
        private readonly IZipArchive epubArchive;
        private bool isDisposed;

        public EpubBookRef(IZipArchive epubArchive)
        {
            this.epubArchive = epubArchive;
            isDisposed = false;
        }

        ~EpubBookRef()
        {
            Dispose(false);
        }

        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> AuthorList { get; set; }
        public EpubSchema Schema { get; set; }
        public EpubContentRef Content { get; set; }

        internal IZipArchive EpubArchive
        {
            get
            {
                return epubArchive;
            }
        }

        public Image ReadCover()
        {
            return ReadCoverAsync().Result;
        }

        public async Task<Image> ReadCoverAsync()
        {
            return await BookCoverReader.ReadBookCoverAsync(this).ConfigureAwait(false);
        }

        public List<EpubChapterRef> GetChapters()
        {
            return GetChaptersAsync().Result;
        }

        public async Task<List<EpubChapterRef>> GetChaptersAsync()
        {
            return await Task.Run(() => ChapterReader.GetChapters(this)).ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    epubArchive.Dispose();
                }
                isDisposed = true;
            }
        }
    }
}
