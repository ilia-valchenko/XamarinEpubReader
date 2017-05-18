//using SQLite;

namespace App1.DAL.Entities
{
    /// <summary>
    /// This class represents a structure which contains business logic configuration for application.
    /// </summary>
    //[Table("SETTINGS")]
    public class SettingsEntity
    {
        /// <summary>
        /// The identifier.
        /// </summary>
        //[PrimaryKey, Column("BOOKID")]
        public string BookId { get; set; }

        /// <summary>
        /// The last page user read.
        /// </summary>
        //[Column("LASTPAGE")]
        public int LastPage { get; set; }

        /// <summary>
        /// The book page font size.
        /// </summary>
        //[Column("FONTSIZE")]
        public int FontSize { get; set; }
    }
}
