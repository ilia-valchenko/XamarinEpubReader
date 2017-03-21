using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpubReaderXamarinForms.EpubReader.Entities;
using EpubReaderXamarinForms.EpubReader.Readers;

namespace EpubReaderXamarinForms.EpubReader.RefEntities
{
    public class EpubBookRef : IDisposable
    {
        private readonly ZipArchive epubArchive;
        private bool isDisposed;

        public EpubBookRef(ZipArchive epubArchive)
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

        internal ZipArchive EpubArchive
        {
            get
            {
                return epubArchive;
            }
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
