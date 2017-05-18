using System.Collections.Generic;
using App1.DAL.Entities;
using App1.DAL.Interfaces;
using SQLitePCL;

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
        /// Initialize a new instance of the <see cref="BookRepository"/>
        /// </summary>
        /// <param name="databaseFilename">The name of the local database file.</param>
        public BookRepository(string databaseFilename)
        {
            //ISQLite sqlLite = DependencyService.Get<ISQLite>();
            //string pathToDatabaseFile = sqlLite.GetLocalDatabaseFilePath(databaseFilename);
            //this.database = new SQLiteConnection(pathToDatabaseFile);

            this.database = new SQLiteConnection(databaseFilename);
            SQLiteResult resultOfTableCreation = this.CreateTable();
        }

        // TODO: Make it async
        private SQLiteResult CreateTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS
                                BOOKS (ID VARCHAR PRIMARY KEY NOT NULL, 
                                       COVER BLOB,
                                       TITLE VARCHAR,
                                       AUTHOR VARCHAR,
                                       FILEPATH VARCHAR);";

            using (var statement = this.database.Prepare(sql))
            {
                SQLiteResult result = statement.Step();
                return result;
            }
        }

        /// <summary>
        /// Gets all books from the repository.
        /// </summary>
        /// <returns>Returns a collection of books entities.</returns>
        public IList<BookEntity> GetAll()
        {
            List<BookEntity> bookEntities = new List<BookEntity>();

            using (var statement = this.database.Prepare("SELECT ID, COVER, TITLE, AUTHOR, FILEPATH FROM BOOKS"))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    BookEntity bookEntity = new BookEntity();
                    bookEntity.Id = (string)statement[0];
                    bookEntity.Cover = (byte[])statement[1];
                    bookEntity.Title = (string)statement[2];
                    bookEntity.Author = (string)statement[3];
                    bookEntity.FilePath = (string) statement[4];

                    bookEntities.Add(bookEntity);
                }
            }
            return bookEntities;
        }

        /// <summary>
        /// Gets book by identifier.
        /// </summary>
        /// <param name="id">The book's identifier.</param>
        /// <returns>Returns a book entity.</returns>
        public BookEntity GetById(string id)
        {
            BookEntity bookEntity = null;

            using (var statement = this.database.Prepare("SELECT ID, COVER, TITLE, AUTHOR, FILEPATH FROM BOOKS WHERE Id=?"))
            {
                statement.Bind(1, id);

                if (statement.Step() == SQLiteResult.ROW)
                {
                    bookEntity = new BookEntity
                    {
                        Id = (string)statement[0],
                        Cover = (byte[])statement[1],
                        Title = (string)statement[2],
                        Author = (string)statement[3],
                        FilePath = (string)statement[4]
                    };
                }
            }

            return bookEntity;
        }

        /// <summary>
        /// This method deletes book by id.
        /// </summary>
        /// <param name="id">The book's identifier.</param>
        /// <returns>Returns status code of the executed operation.</returns>
        /// TODO: Make it async
        public SQLiteResult DeleteById(string id)
        {
            using (var statement = this.database.Prepare("DELETE FROM BOOKS WHERE Id=?"))
            {
                statement.Bind(1, id);
                SQLiteResult result = statement.Step();
                return result;
            }
        }

        /// <summary>
        /// This methos saves a book entity into the database.
        /// </summary>
        /// <param name="book">The book entity.</param>
        /// <returns></returns>
        /// TODO: Make it async
        public SQLiteResult Add(BookEntity book)
        {
            using (var statement = this.database.Prepare("INSERT INTO BOOKS(ID, COVER, TITLE, AUTHOR, FILEPATH) VALUES (?,?,?,?,?)"))
            {
                statement.Bind(1, book.Id);
                statement.Bind(2, book.Cover);
                statement.Bind(3, book.Title);
                statement.Bind(4, book.Author);
                statement.Bind(5, book.FilePath);

                SQLiteResult result = statement.Step();
                return result;
            }
        }

        // Test method
        /// TODO: Make it async
        public SQLiteResult DeleteAll()
        {
            using (var statement = this.database.Prepare("DELETE FROM BOOKS"))
            {
                SQLiteResult result = statement.Step();
                return result;
            }
        }
    }
}
