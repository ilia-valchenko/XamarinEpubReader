using System.Collections.Generic;
using App1.DAL.Entities;

namespace App1.DAL.Interfaces
{
    /// <summary>
    /// This inteface provides basic books operations. 
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Gets all books entities.
        /// </summary>
        /// <returns></returns>
        List<BookEntity> GetAll();
        /// <summary>
        /// Get book entity by id. 
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns></returns>
        BookEntity GetById(string id);
        /// <summary>
        /// Deletes book by identifier. 
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns></returns>
        int DeleteById(string id);
        /// <summary>
        /// Ads book to the database. 
        /// </summary>
        /// <param name="book">The book entity.</param>
        /// <returns></returns>
        int Add(BookEntity book);
    }
}
