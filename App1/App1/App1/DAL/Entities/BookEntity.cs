using SQLite;

namespace App1.DAL.Entities
{
    /// <summary>
    /// This class represents the book entity which stores in the database.
    /// </summary>
    [Table("BOOKS")]
    public class BookEntity
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        [PrimaryKey, Column("ID")]
        public string Id { get; set; }

        /// <summary>
        /// The book's cover image.
        /// </summary>
        [Column("COVER")]
        public byte[] Cover { get; set; }

        /// <summary>
        /// The book's title.
        /// </summary>
        [Column("TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// The name of the author of a book.
        /// </summary>
        [Column("AUTHOR")]
        public string Author { get; set; }

        /// <summary>
        /// The path to the file.
        /// </summary>
        [Column("FILEPATH")]
        public string FilePath { get; set; }
    }
}
