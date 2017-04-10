using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using App1.Infrastructure;
using App1.DAL.Entities;
using App1.DAL.Interfaces;
using App1.Infrastructure.Directory;

namespace App1.DAL.Repositories
{
    /// <summary>
    /// The book repository.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// The database database.
        /// </summary>
        private readonly SQLiteConnection database;

        /// <summary>
        /// The SQLite helper.
        /// </summary>
        private readonly ISQLite sqlLite;

        /// <summary>
        /// The multithreading locker.
        /// </summary>
        private static object locker = new object();

        /// <summary>
        /// Initialize a new instance of the <see cref="BookRepository"/>
        /// </summary>
        /// <param name="filename">The name of the local database file.</param>
        public BookRepository(string filename)
        {
            this.sqlLite = DependencyService.Get<ISQLite>();
            string databasePath = this.sqlLite.GetLocalDatabaseFilePath(filename);

            //IDirectory directory = DependencyService.Get<IDirectory>();
            //string databaseFolderName = "TestFolder";
            //string databaseFolderPath = directory.CreateRootFolder(databaseFolderName);
            //string pathToDatabaseFile = databaseFolderPath + "/" + filename;

            this.database = new SQLiteConnection(/*pathToDatabaseFile*/ databasePath);
            int createTableStatusCode = database.CreateTable<BookEntity>();
        }

        /// <summary>
        /// Gets all books from the repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookEntity> GetAll()
        {
            List<BookEntity> books;

            lock (locker)
            {
                books = this.database.Table<BookEntity>().ToList();
            }

            return books;
        }

        /// <summary>
        /// Gets book by identifier.
        /// </summary>
        /// <param name="id">The book's identifier.</param>
        /// <returns></returns>
        public BookEntity GetById(string id)
        {
            BookEntity book;

            lock(locker)
            {
                book = this.database.Get<BookEntity>(id);
            }
 
            return book;
        }

        /// <summary>
        /// This method deletes book by id.
        /// </summary>
        /// <param name="id">The book's identifier.</param>
        /// <returns></returns>
        public int DeleteById(string id)
        {
            int result;

            lock(locker)
            {
                result = database.Delete<BookEntity>(id);
            }
             
            return result;
        }

        /// <summary>
        /// This methos saves a book entity into the database.
        /// </summary>
        /// <param name="book">The book entity.</param>
        /// <returns></returns>
        public int Add(BookEntity book)
        {
            int result; 

            if(string.IsNullOrEmpty(book.Id))
            {
                Guid newGuid = Guid.NewGuid();
                string id = newGuid.ToNonDashedString();
                book.Id = id;

                lock(locker)
                {
                    result = database.Insert(book);
                }
            }
            else
            {
                lock(locker)
                {
                    result = database.Update(book);
                }
            }

            return result;
        }
    }
}
