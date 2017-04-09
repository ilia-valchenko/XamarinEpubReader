using System.Collections.Generic;
using App1.DAL.Entities;
using App1.Models;

namespace App1.Infrastructure.Mappers
{
    /// <summary>
    /// This class represent the static mapper which maps book entity to the book info view model and vise versa. 
    /// </summary>
    public static class BookEntityToBookInfoModelMapper
    {
        /// <summary>
        /// Convert book entity to the book info view model.
        /// </summary>
        /// <param name="entity">The book entity.</param>
        /// <returns>Book info view model.</returns>
        public static BookInfoViewModel ToBookInfoModelMapper(this BookEntity entity)
        {
            if(entity == null)
            {
                return null;
            }

            BookInfoViewModel model = new BookInfoViewModel(entity.Title, entity.Author, entity.Cover, entity.FilePath);
            return model;
        }

        /// <summary>
        /// Converts a collection of book entities to a collection of book info view models.
        /// </summary>
        /// <param name="booksEntities">A collection of book entities.</param>
        /// <returns>A collection of book info view models.</returns>
        public static List<BookInfoViewModel> ToListOfBookInfoViewModel(this IEnumerable<BookEntity> booksEntities)
        {
            if(booksEntities == null)
            {
                return null;
            }

            List<BookInfoViewModel> models = new List<BookInfoViewModel>();

            foreach(BookEntity entity in booksEntities)
            {
                BookInfoViewModel model = entity.ToBookInfoModelMapper();
                models.Add(model);
            }

            return models;
        }
    }
}
