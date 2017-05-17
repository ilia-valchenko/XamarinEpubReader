using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using App1.DAL.Entities;
using App1.DAL.Interfaces;
using App1.Infrastructure.Interfaces;

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
        /// The multithreading locker.
        /// </summary>
        private static object locker = new object();

        /// <summary>
        /// Initialize a new instance of the <see cref="BookRepository"/>
        /// </summary>
        /// <param name="databaseFilename">The name of the local database file.</param>
        public BookRepository(string databaseFilename)
        {
            ISQLite sqlLite = DependencyService.Get<ISQLite>();
            string pathToDatabaseFile = sqlLite.GetLocalDatabaseFilePath(databaseFilename);
            //this.database = new SQLiteConnection(pathToDatabaseFile);
            this.database = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), dbPath)
            int createTableStatusCode = this.database.CreateTable<BookEntity>();
        }

        /// <summary>
        /// Gets all books from the repository.
        /// </summary>
        /// <returns>Returns a collection of books entities.</returns>
        /// TODO: Make it async
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
        /// <returns>Returns a book entity.</returns>
        /// TODO: Make it async
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
        /// <returns>Returns status code of the executed operation.</returns>
        /// TODO: Make it async
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
        /// <returns>Returns status code of the executed operation.</returns>
        /// TODO: Make it async
        public int Add(BookEntity book)
        {
            int result; 

            if(string.IsNullOrEmpty(book.Id))
            {
                throw new ArgumentException("Book identifier can't be null or empty.");
            }

            lock (locker)
            {
                result = database.Insert(book);
            }

            return result;
        }

        // Test method
        /// TODO: Make it async
        public int DeleteAll()
        {
            int statusCode = this.database.Execute("DELETE FROM BOOKS");
            return statusCode;
        }
    }
}
